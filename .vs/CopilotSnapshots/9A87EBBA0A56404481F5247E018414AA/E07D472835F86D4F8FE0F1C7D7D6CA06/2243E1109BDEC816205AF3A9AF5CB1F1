using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers;

public class HopDongController : Controller
{
    private readonly QLNLContext _context;

    public HopDongController(QLNLContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(LoaiHopDong? loaiHopDong = null, TrangThaiHopDong? trangThai = null, string? keyword = null)
    {
        var query = _context.HopDongs
            .Include(h => h.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .AsQueryable();

        if (loaiHopDong.HasValue)
            query = query.Where(h => h.LoaiHopDong == loaiHopDong.Value);

        if (trangThai.HasValue)
            query = query.Where(h => h.TrangThai == trangThai.Value);

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(h => h.NhanSu.HoVaTen.Contains(keyword) || h.MaHopDong.Contains(keyword));

        var hopDongs = await query
            .OrderByDescending(h => h.NgayKy)
            .Select(h => new HopDongVM
            {
                Id = h.Id,
                MaHopDong = h.MaHopDong,
                NhanSuId = h.NhanSuId,
                MaNhanVien = h.NhanSu.MaNhanVien,
                HoTen = h.NhanSu.HoVaTen,
                PhongBan = h.NhanSu.PhongBan.TenPhongBan,
                LoaiHopDong = h.LoaiHopDong,
                NgayKy = h.NgayKy,
                NgayBatDau = h.NgayBatDau,
                NgayKetThuc = h.NgayKetThuc,
                LuongCoBan = h.LuongCoBan,
                TrangThai = h.TrangThai,
                GhiChu = h.GhiChu
            })
            .ToListAsync();

        ViewBag.NhanSuList = new SelectList(await _context.NhanSus.ToListAsync(), "Id", "HoVaTen");
        return View(hopDongs);
    }

    [HttpGet]
    public async Task<IActionResult> GetHopDong(Guid id)
    {
        var hopDong = await _context.HopDongs
            .Include(h => h.NhanSu)
            .FirstOrDefaultAsync(h => h.Id == id);
        
        if (hopDong == null) return NotFound();
        
        return Json(new
        {
            id = hopDong.Id,
            maHopDong = hopDong.MaHopDong,
            nhanSuId = hopDong.NhanSuId,
            hoTen = hopDong.NhanSu.HoVaTen,
            loaiHopDong = (int)hopDong.LoaiHopDong,
            ngayKy = hopDong.NgayKy.ToString("yyyy-MM-dd"),
            ngayBatDau = hopDong.NgayBatDau.ToString("yyyy-MM-dd"),
            ngayKetThuc = hopDong.NgayKetThuc?.ToString("yyyy-MM-dd"),
            luongCoBan = hopDong.LuongCoBan,
            trangThai = (int)hopDong.TrangThai,
            ghiChu = hopDong.GhiChu
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAjax([FromForm] HopDongVM model)
    {
        if (model.NhanSuId == Guid.Empty)
            return Json(new { success = false, message = "Vui lòng chọn nhân viên" });

        var hopDong = new HopDong
        {
            MaHopDong = $"HD-{DateTime.Now:yyyyMMddHHmmss}",
            NhanSuId = model.NhanSuId,
            LoaiHopDong = model.LoaiHopDong,
            NgayKy = model.NgayKy,
            NgayBatDau = model.NgayBatDau,
            NgayKetThuc = model.NgayKetThuc,
            LuongCoBan = model.LuongCoBan,
            TrangThai = TrangThaiHopDong.HieuLuc,
            GhiChu = model.GhiChu
        };

        _context.HopDongs.Add(hopDong);
        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> EditAjax([FromForm] HopDongVM model)
    {
        var hopDong = await _context.HopDongs.FindAsync(model.Id);
        if (hopDong == null)
            return Json(new { success = false, message = "Không tìm thấy hợp đồng" });

        hopDong.LoaiHopDong = model.LoaiHopDong;
        hopDong.NgayKy = model.NgayKy;
        hopDong.NgayBatDau = model.NgayBatDau;
        hopDong.NgayKetThuc = model.NgayKetThuc;
        hopDong.LuongCoBan = model.LuongCoBan;
        hopDong.TrangThai = model.TrangThai;
        hopDong.GhiChu = model.GhiChu;

        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAjax([FromForm] Guid id)
    {
        var hopDong = await _context.HopDongs.FindAsync(id);
        if (hopDong == null)
            return Json(new { success = false, message = "Không tìm thấy hợp đồng" });

        _context.HopDongs.Remove(hopDong);
        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> ChamDutHopDong([FromForm] Guid id)
    {
        var hopDong = await _context.HopDongs.FindAsync(id);
        if (hopDong == null)
            return Json(new { success = false, message = "Không tìm thấy hợp đồng" });

        hopDong.TrangThai = TrangThaiHopDong.ChamDut;
        hopDong.NgayKetThuc = DateTime.Now;

        await _context.SaveChangesAsync();
        return Json(new { success = true });
    }
}
