namespace QuanLyNhanLuc.Models.ViewModels;

public class BaoHiemVM
{
    public int Id { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public string SoBHXH { get; set; }
    public string SoBHXHCu { get; set; }
    public string SoBHYT { get; set; }
    public DateTime NgayThamGia { get; set; }
    public DateTime NgayCapThe { get; set; }
    public DateTime NgayHetHan { get; set; }
    public string NoiDangKyBHXH { get; set; }
    public string NoiDangKyKCB { get; set; }
    public string MaKCB { get; set; }
    public string MaTinhBenhVien { get; set; }
    public bool DaTraTheBHYT { get; set; }
    public DateTime NgayThamGiaBHTN { get; set; }
    public int ThoiGianDongBHTN { get; set; }
} 