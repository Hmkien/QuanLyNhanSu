using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Data;

public static class DbInitializer
{
    public static void Initialize(QLNLContext context)
    {
        // Đảm bảo database đã được tạo
        context.Database.EnsureCreated();

        // Kiểm tra xem đã có dữ liệu chưa
        if (context.PhongBans.Any())
        {
            return; // Database đã được seed
        }

        // Thêm dữ liệu mẫu cho PhongBan
        var phongBans = new PhongBan[]
        {
            new PhongBan { MaPhongBan = "FE", TenPhongBan = "Frontend", MoTa = "Phòng phát triển Frontend" },
            new PhongBan { MaPhongBan = "BE", TenPhongBan = "Backend", MoTa = "Phòng phát triển Backend" },
            new PhongBan { MaPhongBan = "QA", TenPhongBan = "Quality Assurance", MoTa = "Phòng kiểm thử chất lượng" },
            new PhongBan { MaPhongBan = "HR", TenPhongBan = "Human Resources", MoTa = "Phòng nhân sự" }
        };
        context.PhongBans.AddRange(phongBans);
        context.SaveChanges();

        // Thêm dữ liệu mẫu cho NhanSu
        var nhanSus = new NhanSu[]
        {
            new NhanSu { MaNhanVien = "NS001", HoVaTen = "Nguyễn Văn A", PhongBanId = 1 },
            new NhanSu { MaNhanVien = "NS002", HoVaTen = "Trần Thị B", PhongBanId = 2 },
            new NhanSu { MaNhanVien = "NS003", HoVaTen = "Lê Văn C", PhongBanId = 3 },
            new NhanSu { MaNhanVien = "NS004", HoVaTen = "Phạm Thị D", PhongBanId = 4 }
        };
        context.NhanSus.AddRange(nhanSus);
        context.SaveChanges();

        // Thêm dữ liệu mẫu cho ChamCong
        var chamCongs = new ChamCong[]
        {
            new ChamCong 
            { 
                NhanSuId = 1,
                NgayChamCong = new DateTime(2023, 7, 1),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            },
            new ChamCong 
            { 
                NhanSuId = 1,
                NgayChamCong = new DateTime(2023, 7, 2),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            },
            new ChamCong 
            { 
                NhanSuId = 1,
                NgayChamCong = new DateTime(2023, 7, 3),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            },
            new ChamCong 
            { 
                NhanSuId = 2,
                NgayChamCong = new DateTime(2023, 7, 1),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            },
            new ChamCong 
            { 
                NhanSuId = 2,
                NgayChamCong = new DateTime(2023, 7, 2),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            },
            new ChamCong 
            { 
                NhanSuId = 2,
                NgayChamCong = new DateTime(2023, 7, 3),
                GioVao = new TimeSpan(8, 0, 0),
                GioRa = new TimeSpan(17, 0, 0),
                TrangThai = TrangThaiChamCong.DiLam,
                GhiChu = "Đi làm đúng giờ"
            }
        };
        context.ChamCongs.AddRange(chamCongs);
        context.SaveChanges();

        // Thêm dữ liệu mẫu cho LichLamThem
        var lichLamThems = new LichLamThem[]
        {
            new LichLamThem
            {
                NhanSuId = 3,
                NgayLamThem = new DateTime(2023, 7, 4),
                GioBatDau = new TimeSpan(18, 0, 0),
                GioKetThuc = new TimeSpan(21, 0, 0),
                LyDo = "Hoàn thành dự án gấp",
                TrangThai = TrangThaiLamThem.ChuaDuyet,
                NguoiDuyet = "Admin"
            },
            new LichLamThem
            {
                NhanSuId = 4,
                NgayLamThem = new DateTime(2023, 7, 5),
                GioBatDau = new TimeSpan(18, 0, 0),
                GioKetThuc = new TimeSpan(22, 0, 0),
                LyDo = "Họp dự án",
                TrangThai = TrangThaiLamThem.DaDuyet,
                NguoiDuyet = "Admin"
            }
        };
        context.LichLamThems.AddRange(lichLamThems);
        context.SaveChanges();
    }
} 