using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;
using QuanLyNhanLuc.Models.ViewModels;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace QuanLyNhanLuc.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNLContext _context;
        private readonly UserManager<NguoiDung> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(QLNLContext context, UserManager<NguoiDung> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy thông tin nhân viên
            var thongTinNhanVien = await _context.ThongTinNguoiDungs
                .Include(x => x.User)
                .Include(x => x.Department)
                .Include(x => x.ChucVu)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (thongTinNhanVien == null)
            {
                return NotFound();
            }

            ViewBag.ThongTinNhanVien = thongTinNhanVien;

            // Lấy danh sách nhiệm vụ
            var danhSachNhiemVu = await _context.NhiemVus
                .Where(x => x.NhanVienId == thongTinNhanVien.Id)
                .OrderByDescending(x => x.Created)
                .ToListAsync();

            ViewBag.DanhSachNhiemVu = danhSachNhiemVu;

            // Lấy lịch sử điểm danh
            var lichSuDiemDanh = await _context.DiemDanhs
                .Where(x => x.NhanVienId == thongTinNhanVien.Id)
                .OrderByDescending(x => x.NgayDiemDanh)
                .Take(10)
                .ToListAsync();

            ViewBag.LichSuDiemDanh = lichSuDiemDanh;

            // Lấy thông tin điểm danh hôm nay
            var today = DateTime.Now.Date;
            var diemDanhHomNay = await _context.DiemDanhs
                .FirstOrDefaultAsync(x => x.NhanVienId == thongTinNhanVien.Id && x.NgayDiemDanh.Date == today);

            var diemDanhVM = new DiemDanhVM
            {
                DaDiemDanhDen = diemDanhHomNay?.GioDen != null,
                DaDiemDanhVe = diemDanhHomNay?.GioVe != null,
                GioDen = diemDanhHomNay?.GioDen,
                GioVe = diemDanhHomNay?.GioVe,
                TrangThai = diemDanhHomNay?.TrangThai ?? TrangThaiDiemDanh.DungGio,
                CoTheDiemDanh = true,
                ThongBao = "Bạn có thể điểm danh"
            };

            // Xác định trạng thái điểm danh
            if (diemDanhVM.DaDiemDanhDen && diemDanhVM.DaDiemDanhVe)
            {
                diemDanhVM.CoTheDiemDanh = false;
                diemDanhVM.ThongBao = "Bạn đã hoàn thành điểm danh hôm nay";
                
                // Tính thời gian làm việc
                if (diemDanhVM.GioDen.HasValue && diemDanhVM.GioVe.HasValue)
                {
                    diemDanhVM.ThoiGianLamViec = diemDanhVM.GioVe.Value - diemDanhVM.GioDen.Value;
                    diemDanhVM.ThoiGianLamViecText = $"{diemDanhVM.ThoiGianLamViec.Value.Hours} giờ {diemDanhVM.ThoiGianLamViec.Value.Minutes} phút";
                }
            }
            else if (diemDanhVM.DaDiemDanhDen && !diemDanhVM.DaDiemDanhVe)
            {
                diemDanhVM.ThongBao = "Bạn đã điểm danh đến, vui lòng điểm danh về khi kết thúc công việc";
            }
            else if (!diemDanhVM.DaDiemDanhDen && !diemDanhVM.DaDiemDanhVe)
            {
                diemDanhVM.ThongBao = "Vui lòng điểm danh đến để bắt đầu ngày làm việc";
            }

            // Xác định class và text cho trạng thái
            switch (diemDanhVM.TrangThai)
            {
                case TrangThaiDiemDanh.DungGio:
                    diemDanhVM.TrangThaiText = "Đúng giờ";
                    diemDanhVM.TrangThaiClass = "success";
                    break;
                case TrangThaiDiemDanh.Muon:
                    diemDanhVM.TrangThaiText = "Đi muộn";
                    diemDanhVM.TrangThaiClass = "warning";
                    break;
                case TrangThaiDiemDanh.Som:
                    diemDanhVM.TrangThaiText = "Về sớm";
                    diemDanhVM.TrangThaiClass = "info";
                    break;
                default:
                    diemDanhVM.TrangThaiText = "Chưa xác định";
                    diemDanhVM.TrangThaiClass = "secondary";
                    break;
            }

            ViewBag.DiemDanhVM = diemDanhVM;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DiemDanhDen()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
            }

            var nhanVien = await _context.ThongTinNguoiDungs
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (nhanVien == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin nhân viên" });
            }

            var now = DateTime.Now;
            var diemDanh = await _context.DiemDanhs
                .FirstOrDefaultAsync(x => x.NhanVienId == nhanVien.Id && x.NgayDiemDanh.Date == now.Date);

            if (diemDanh == null)
            {
                diemDanh = new DiemDanh
                {
                    NhanVienId = nhanVien.Id,
                    NgayDiemDanh = now,
                    GioDen = now,
                    TrangThai = now.Hour >= 8 ? TrangThaiDiemDanh.Muon : TrangThaiDiemDanh.DungGio
                };
                _context.DiemDanhs.Add(diemDanh);
            }
            else if (diemDanh.GioDen == null)
            {
                diemDanh.GioDen = now;
                diemDanh.TrangThai = now.Hour >= 8 ? TrangThaiDiemDanh.Muon : TrangThaiDiemDanh.DungGio;
            }
            else
            {
                return Json(new { success = false, message = "Bạn đã điểm danh đến rồi" });
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Điểm danh đến thành công" });
        }

        [HttpPost]
        public async Task<IActionResult> DiemDanhVe()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
            }

            var nhanVien = await _context.ThongTinNguoiDungs
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (nhanVien == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin nhân viên" });
            }

            var now = DateTime.Now;
            var diemDanh = await _context.DiemDanhs
                .FirstOrDefaultAsync(x => x.NhanVienId == nhanVien.Id && x.NgayDiemDanh.Date == now.Date);

            if (diemDanh == null)
            {
                return Json(new { success = false, message = "Bạn chưa điểm danh đến" });
            }

            if (diemDanh.GioVe != null)
            {
                return Json(new { success = false, message = "Bạn đã điểm danh về rồi" });
            }

            diemDanh.GioVe = now;
            if (now.Hour < 17)
            {
                diemDanh.TrangThai = TrangThaiDiemDanh.Som;
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Điểm danh về thành công" });
        }

        [HttpPost]
        public async Task<IActionResult> ThemNhiemVu([FromForm] NhiemVu nhiemVu)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
            }

            var nhanVien = await _context.ThongTinNguoiDungs
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (nhanVien == null)
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin nhân viên" });
            }

            nhiemVu.Id = Guid.NewGuid();
            nhiemVu.NhanVienId = nhanVien.Id;
            nhiemVu.TrangThai = TrangThaiNhiemVu.ChuaBatDau;
            nhiemVu.Created = DateTime.Now;
            nhiemVu.Status = (Status)1;

            _context.NhiemVus.Add(nhiemVu);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> CapNhatTrangThaiNhiemVu(Guid id)
        {
            var nhiemVu = await _context.NhiemVus.FindAsync(id);
            if (nhiemVu == null)
            {
                return Json(new { success = false, message = "Không tìm thấy nhiệm vụ" });
            }

            nhiemVu.TrangThai = nhiemVu.TrangThai switch
            {
                TrangThaiNhiemVu.ChuaBatDau => TrangThaiNhiemVu.DangThucHien,
                TrangThaiNhiemVu.DangThucHien => TrangThaiNhiemVu.HoanThanh,
                _ => nhiemVu.TrangThai
            };

            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> XoaNhiemVu(Guid id)
        {
            var nhiemVu = await _context.NhiemVus.FindAsync(id);
            if (nhiemVu == null)
            {
                return Json(new { success = false, message = "Không tìm thấy nhiệm vụ" });
            }

            _context.NhiemVus.Remove(nhiemVu);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> CapNhatThongTin(IFormCollection form)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _context.Users
                    .Include(u => u.ThongTinNguoiDung)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null || user.ThongTinNguoiDung == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin người dùng" });
                }

                var thongTin = user.ThongTinNguoiDung;

                // Cập nhật thông tin cơ bản
                thongTin.FullName = form["FullName"];
                thongTin.BirthDay = DateTime.Parse(form["BirthDay"]);
                thongTin.GioiTinh = (GioiTinh)int.Parse(form["GioiTinh"]);
                thongTin.IdentityNumber = form["IdentityNumber"];

                // Xử lý ảnh đại diện nếu có
                var file = form.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    var fileName = $"{userId}_{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "avatars", fileName);

                    // Tạo thư mục nếu chưa tồn tại
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Xóa ảnh cũ nếu có
                    if (!string.IsNullOrEmpty(thongTin.ImageLink))
                    {
                        var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, thongTin.ImageLink.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Lưu ảnh mới
                    using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    thongTin.ImageLink = $"/uploads/avatars/{fileName}";
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Cập nhật thông tin thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
} 