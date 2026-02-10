using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Enums;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers
{
    public class BaoCaoController : Controller
    {
        private readonly QLNLContext _context;

        public BaoCaoController(QLNLContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Thống kê tổng quan
            ViewBag.TongNhanVien = _context.ThongTinNguoiDungs.Count(x => x.NhanSuType != NhanSuType.ThucTapSinh);
            ViewBag.TongThucTapSinh = _context.ThongTinNguoiDungs.Count(x => x.NhanSuType == NhanSuType.ThucTapSinh);
            ViewBag.TongNam = _context.ThongTinNguoiDungs.Count(x => x.GioiTinh == GioiTinh.Male);
            ViewBag.TongNu = _context.ThongTinNguoiDungs.Count(x => x.GioiTinh == GioiTinh.Female);

            // Thống kê theo phòng ban
            List<ThongKePhongBanVM> thongKePhongBan = _context.PhongBans
                .Include(d => d.ThongTinNguoiDungs)
                .Select(d => new ThongKePhongBanVM
                {
                    TenPhongBan = d.TenPhongBan,
                    TongSo = d.ThongTinNguoiDungs.Count,
                    SoNam = d.ThongTinNguoiDungs.Count(x => x.GioiTinh == GioiTinh.Male),
                    SoNu = d.ThongTinNguoiDungs.Count(x => x.GioiTinh == GioiTinh.Female),
                    SoThucTapSinh = d.ThongTinNguoiDungs.Count(x => x.NhanSuType == NhanSuType.ThucTapSinh)
                })
                .ToList();

            ViewBag.ThongKePhongBan = thongKePhongBan;
            ViewBag.DepartmentLabels = thongKePhongBan.Select(x => x.TenPhongBan).ToList();
            ViewBag.DepartmentData = thongKePhongBan.Select(x => x.TongSo).ToList();

            // Thống kê theo chức vụ
            List<ThongKeChucVuVM> thongKeChucVu = _context.ChucVus
                .Include(c => c.NhanSus)
                .Select(c => new ThongKeChucVuVM
                {
                    TenChucVu = c.TenChucVu,
                    SoLuong = c.NhanSus.Count
                })
                .ToList();

            ViewBag.PositionLabels = thongKeChucVu.Select(x => x.TenChucVu).ToList();
            ViewBag.PositionData = thongKeChucVu.Select(x => x.SoLuong).ToList();

            return View();
        }
    }
}
