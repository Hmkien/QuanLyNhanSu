using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class DiemDanh : EntityBase
{
    public Guid NhanVienId { get; set; }
    public virtual ThongTinNguoiDung? NhanVien { get; set; }
    public DateTime NgayDiemDanh { get; set; }
    public DateTime? GioDen { get; set; }
    public DateTime? GioVe { get; set; }
    public TrangThaiDiemDanh TrangThai { get; set; }
    public string? GhiChu { get; set; }
} 