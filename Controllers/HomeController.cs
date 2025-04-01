using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;
using System.Security.Claims;

namespace QuanLyNhanLuc.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNLContext _context;
        private readonly UserManager<NguoiDung> _userManager;

        public HomeController(QLNLContext context, UserManager<NguoiDung> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            return Json(new { success = true });
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
            return Json(new { success = true });
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
    }
} 