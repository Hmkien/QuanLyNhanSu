namespace QuanLyNhanLuc.Models;

public class NhanVien : EntityBase
{
    public string HoTen { get; set; } = string.Empty;
    public string GioiTinh { get; set; } = string.Empty;
    public DateTime NgaySinh { get; set; }
    public DateTime NgayVaoLam { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public Guid PhongBanId { get; set; }
    public PhongBan PhongBan { get; set; } = null!;
}
