using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class QuanHeGiaDinh : EntityBase
{
    public string? NguoiDungId { get; set; }
    public virtual NguoiDung? NguoiDung { get; set; }

    public string? TenNguoiThan { get; set; }
    public GioiTinh? GioiTinh { get; set; }
    public DateTime? NgaySinh { get; set; }
    public string? DienThoai { get; set; }
    public string? QuanHeVoiChuHo { get; set; }
    public string? DiaChi { get; set; }
    public string? NgheNghiep { get; set; }
}
