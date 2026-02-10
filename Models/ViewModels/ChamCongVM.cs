using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.ViewModels;

public class ChamCongVM
{
    public Guid Id { get; set; }
    public string MaNhanVien { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string PhongBan { get; set; } = string.Empty;
    public DateTime NgayChamCong { get; set; }
    public TimeSpan? GioVao { get; set; }
    public TimeSpan? GioRa { get; set; }
    public string TrangThai { get; set; }
    public string GhiChu { get; set; } = string.Empty;
}

public class LichLamThemVM
{
    public Guid Id { get; set; }
    public string MaNhanVien { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string PhongBan { get; set; } = string.Empty;
    public DateTime NgayLamThem { get; set; }
    public TimeSpan GioBatDau { get; set; }
    public TimeSpan GioKetThuc { get; set; }
    public string LyDo { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string NguoiDuyet { get; set; } = string.Empty;
} 