using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Extensions;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.ViewModels;
namespace QuanLyNhanLuc.Controllers;

public class NhanSuController : Controller
{
    private readonly QLNLContext _context;
    private readonly UserManager<NguoiDung> _userManager;
    public NhanSuController(QLNLContext context, UserManager<NguoiDung> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    public IActionResult DanhSachNhanVien()
    {
        var nhanvien = (from ttnd in _context.ThongTinNguoiDungs
                        join nd in _context.NguoiDungs on ttnd.UserId equals nd.Id
                        where ttnd.NhanSuType != NhanSuType.ThucTapSinh
                        select new NhanVienListVM
                        {
                            Id = ttnd.Id,
                            FullName = ttnd.FullName,
                            IdentityNumber = ttnd.IdentityNumber,
                            GioiTinhStxt = ttnd.GioiTinhStxt,
                            DepartmentName = ttnd.Department.TenPhongBan,
                            PositionName = ttnd.ChucVu.TenChucVu,
                            Email = nd.Email,
                            PhoneNumber = nd.PhoneNumber
                        }).ToList();

        return View(nhanvien);
    }
    public IActionResult DanhSachThucTap()
    {
        var thucTapSinh = (from ttnd in _context.ThongTinNguoiDungs
                           join nd in _context.NguoiDungs on ttnd.UserId equals nd.Id
                           where ttnd.NhanSuType == NhanSuType.ThucTapSinh
                           select new
                           {
                               ttnd.Id,
                               ttnd.FullName,
                               ttnd.IdentityNumber,
                               ttnd.GioiTinhStxt,
                               DepartmentName = ttnd.Department.TenPhongBan,
                               PositionName = ttnd.ChucVu.TenChucVu,
                               nd.Email,
                               nd.PhoneNumber
                           }).ToList();

        return View(thucTapSinh);
    }
    public IActionResult GetModalThemNhanSu()
    {
        ThemNhanVienVM model = new ThemNhanVienVM();
        model.Departments = new SelectList(_context.Departments.ToList(), "Id", "TenPhongBan");
        model.ChucVus = new SelectList(_context.ChucVus.ToList(), "Id", "TenChucVu");
        return PartialView("~/Views/Modals/_ModalThemNhanSu.cshtml", model);
    }
    public IActionResult ChiTietNhanVien()
    {
        return View();
    }
    public IActionResult GetModalConfirmDelete(Guid id)
    {
        return PartialView("~/Views/Modals/_ModalConfirmDelete.cshtml", id);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> XoaNhanVien(Guid id)
    {
        try
        {
            var nhanVien = await _context.ThongTinNguoiDungs
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            // Xóa thông tin người dùng
            _context.ThongTinNguoiDungs.Remove(nhanVien);

            // Xóa người dùng
            if (nhanVien.User != null)
            {
                await _userManager.DeleteAsync(nhanVien.User);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Xóa nhân viên thành công!";
            return RedirectToAction(nameof(DanhSachNhanVien));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa nhân viên: " + ex.Message;
            return RedirectToAction(nameof(DanhSachNhanVien));
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeViewModel nhanVien)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("DanhSachNhanVien");
        }

        string fileName = "";
        if (nhanVien.AnhDaiDien != null && nhanVien.AnhDaiDien.Length > 0)
        {
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(nhanVien.AnhDaiDien.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await nhanVien.AnhDaiDien.CopyToAsync(stream);
            }
        }

        var employee = new ThongTinNguoiDung
        {
            FullName = nhanVien.HoVaTen,
            GioiTinh = nhanVien.GioiTinh,
            GioiTinhStxt = nhanVien.GioiTinh.GetDescription(),
            BirthDay = nhanVien.NgaySinh,
            IdentityNumber = nhanVien.CCCD,
            DepartmentId = nhanVien.PhongBanId,
            ChucVuId = nhanVien.ChucVuId,
            NhanSuType = nhanVien.LoaiNhanSu,
            NhanSuTypeStxt = nhanVien?.LoaiNhanSu.GetDescription(),
            ImageLink = fileName
        };

        var user = new NguoiDung
        {
            UserName = nhanVien.Email,
            Email = nhanVien.Email,
            PhoneNumber = nhanVien.SoDienThoai,
            MaNhanVien = nhanVien.MaNhanVien
        };
        employee.UserId = user.Id;
        var result = await _userManager.CreateAsync(user, nhanVien.MatKhau);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(nhanVien);
        }

        await _context.ThongTinNguoiDungs.AddAsync(employee);
        await _context.SaveChangesAsync();
        if (nhanVien.LoaiNhanSu == NhanSuType.ThucTapSinh)
        {
            return RedirectToAction("DanhSachThucTap");
        }
        return RedirectToAction("DanhSachNhanVien");
    }
}
