using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class NhiemVu : EntityBase
{
    public string TenNhiemVu { get; set; } = string.Empty;
    public string? MoTa { get; set; }
    public DateTime HanHoanThanh { get; set; }
    public TrangThaiNhiemVu TrangThai { get; set; }
    public Guid NhanVienId { get; set; }
    public virtual ThongTinNguoiDung? NhanVien { get; set; }
} 