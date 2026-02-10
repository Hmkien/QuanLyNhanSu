using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers;

public class KhenThuongKyLuatController : Controller
{
    private readonly QLNLContext _context;

    public KhenThuongKyLuatController(QLNLContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(LoaiKhenThuongKyLuat? loai = null, TrangThaiKhenThuongKyLuat? trangThai = null, string? keyword = null)
    {
        var query = _context.KhenThuongKyLuats
            .Include(k => k.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .AsQueryable();

        if (loai.HasValue)
            query = query.Where(k => k.Loai == loai.Value);

        if (trangThai.HasValue)
            query = query.Where(k => k.TrangThai == trangThai.Value);

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(k => k.NhanSu.HoVaTen.Contains(keyword) || k.MaQuyetDinh.Contains(keyword));

        var khenThuongKyLuats = await query
            .OrderByDescending(k => k.NgayQuyetDinh)
            .Select(k => new KhenThuongKyLuatVM
            {
                Id = k.Id,
                MaQuyetDinh = k.MaQuyetDinh,
                NhanSuId = k.NhanSuId,
                MaNhanVien = k.NhanSu.MaNhanVien,
                HoTen = k.NhanSu.HoVaTen,
                PhongBan = k.NhanSu.PhongBan.TenPhongBan,
                Loai = k.Loai,
                HinhThuc = k.HinhThuc,
                SoTien = k.SoTien,
                LyDo = k.LyDo,
                NgayQuyetDinh = k.NgayQuyetDinh,
                NgayHieuLuc = k.NgayHieuLuc,
                TrangThai = k.TrangThai,
                NguoiDuyet = k.NguoiDuyet,
                NgayDuyet = k.NgayDuyet,
                GhiChu = k.GhiChu
            })
            .ToListAsync();

        ViewBag.NhanSuList = new SelectList(await _context.NhanSus.ToListAsync(), "Id", "HoVaTen");
        return View(khenThuongKyLuats);
    }

    [HttpGet]
    public async Task<IActionResult> GetKhenThuongKyLuat(Guid id)
    {
        var item = await _context.KhenThuongKyLuats
            .Include(k => k.NhanSu)
            .FirstOrDefaultAsync(k => k.Id == id);
        
        if (item == null) return NotFound();
        
        return Json(new
        {
            id = item.Id,
            maQuyetDinh = item.MaQuyetDinh,
            nhanSuId = item.NhanSuId,
            hoTen = item.NhanSu.HoVaTen,
            loai = (int)item.Loai,
            hinhThuc = item.HinhThuc,
            soTien = item.SoTien,
            lyDo = item.LyDo,
            ngayQuyetDinh = item.NgayQuyetDinh.ToString("yyyy-MM-dd"),
            ngayHieuLuc = item.NgayHieuLuc?.ToString("yyyy-MM-dd"),
            trangThai = (int)item.TrangThai,
            ghiChu = item.GhiChu
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAjax([FromForm] KhenThuongKyLuatVM model)
    {
        if (model.NhanSuId == Guid.Empty)
            return Json(new { success = false, message = "Vui lòng chọn nhân viên" });

        var item = new KhenThuongKyLuat
        {
            MaQuyetDinh = $"QD-{DateTime.Now:yyyyMMddHHmmss}",
            NhanSuId = model.NhanSuId,
            Loai = model.Loai,
            HinhThuc = model.HinhThuc,
            SoTien = model.SoTien,
            LyDo = model.LyDo,
            NgayQuyetDinh = model.NgayQuyetDinh,
            NgayHieuLuc = model.NgayHieuLuc,
            TrangThai = TrangThaiKhenThuongKyLuat.ChoDuyet,
            GhiChu = model.GhiChu
        };

        _context.KhenThuongKyLuats.Add(item);
        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> EditAjax([FromForm] KhenThuongKyLuatVM model)
    {
        var item = await _context.KhenThuongKyLuats.FindAsync(model.Id);
        if (item == null)
            return Json(new { success = false, message = "Không tìm thấy quyết định" });

        if (item.TrangThai == TrangThaiKhenThuongKyLuat.DaDuyet)
            return Json(new { success = false, message = "Không thể sửa quyết định đã được duyệt" });

        item.Loai = model.Loai;
        item.HinhThuc = model.HinhThuc;
        item.SoTien = model.SoTien;
        item.LyDo = model.LyDo;
        item.NgayQuyetDinh = model.NgayQuyetDinh;
        item.NgayHieuLuc = model.NgayHieuLuc;
        item.GhiChu = model.GhiChu;

        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> DuyetAjax([FromForm] Guid id, [FromForm] TrangThaiKhenThuongKyLuat trangThai, [FromForm] string? ghiChu)
    {
        var item = await _context.KhenThuongKyLuats.FindAsync(id);
        if (item == null)
            return Json(new { success = false, message = "Không tìm thấy quyết định" });

        item.TrangThai = trangThai;
        item.NgayDuyet = DateTime.Now;
        item.NguoiDuyet = User.Identity?.Name ?? "Admin";
        if (!string.IsNullOrEmpty(ghiChu))
            item.GhiChu = ghiChu;

        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAjax([FromForm] Guid id)
    {
        var item = await _context.KhenThuongKyLuats.FindAsync(id);
        if (item == null)
            return Json(new { success = false, message = "Không tìm thấy quyết định" });

        if (item.TrangThai == TrangThaiKhenThuongKyLuat.DaDuyet)
            return Json(new { success = false, message = "Không thể xóa quyết định đã được duyệt" });

        _context.KhenThuongKyLuats.Remove(item);
        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }
}
