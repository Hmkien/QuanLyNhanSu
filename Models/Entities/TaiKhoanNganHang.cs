namespace QuanLyNhanLuc.Models.Entities;

public class TaiKhoanNganHang : EntityBase
{
    public string? NguoiDungId { get; set; }
    public virtual NguoiDung? NguoiDung { get; set; }

    public string? TenNganHang { get; set; }
    public string? ChiNhanh { get; set; }
    public string? SoTaiKhoan { get; set; }
    public string? TenChuTaiKhoan { get; set; }
}
