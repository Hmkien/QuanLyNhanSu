using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.ViewModels;

public class ChamCongVM
{
    public int Id { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public DateTime NgayChamCong { get; set; }
    public TimeSpan? GioVao { get; set; }
    public TimeSpan? GioRa { get; set; }
    public string TrangThai { get; set; }
    public string GhiChu { get; set; }
}

public class LichLamThemVM
{
    public int Id { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public DateTime NgayLamThem { get; set; }
    public TimeSpan GioBatDau { get; set; }
    public TimeSpan GioKetThuc { get; set; }
    public string LyDo { get; set; }
    public string TrangThai { get; set; }
    public string NguoiDuyet { get; set; }
} 