using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;
using QuanLyNhanLuc.Models.Extensions;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers;

public class ChamCongController : Controller
{
    private readonly QLNLContext _context;

    public ChamCongController(QLNLContext context)
    {
        _context = context;
    }

    public IActionResult BangChamCong()
    {
        var chamCongs = _context.ChamCongs
            .Include(c => c.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .Where(c => c.NgayChamCong.Month == 7 && c.NgayChamCong.Year == 2023)
            .OrderBy(c => c.NgayChamCong)
            .Select(c => new ChamCongVM
            {
                Id = c.Id,
                MaNhanVien = c.NhanSu.MaNhanVien,
                HoTen = c.NhanSu.HoVaTen,
                PhongBan = c.NhanSu.PhongBan.MaPhongBan,
                NgayChamCong = c.NgayChamCong,
                GioVao = c.GioVao,
                GioRa = c.GioRa,
                TrangThai = c.TrangThai.GetDescription(),
                GhiChu = c.GhiChu
            })
            .ToList();

        return View(chamCongs);
    }

    public IActionResult LichLamThem()
    {
        var lichLamThems = _context.LichLamThems
            .Include(l => l.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .Select(l => new LichLamThemVM
            {
                Id = l.Id,
                MaNhanVien = l.NhanSu.MaNhanVien,
                HoTen = l.NhanSu.HoVaTen,
                PhongBan = l.NhanSu.PhongBan.MaPhongBan,
                NgayLamThem = l.NgayLamThem,
                GioBatDau = l.GioBatDau,
                GioKetThuc = l.GioKetThuc,
                LyDo = l.LyDo,
                TrangThai = l.TrangThai.GetDescription(),
                NguoiDuyet = l.NguoiDuyet
            })
            .ToList();

        return View(lichLamThems);
    }
}
