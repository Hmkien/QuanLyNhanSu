using QuanLyNhanLuc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class KhenThuongKyLuat : EntityBase
{
    [MaxLength(50)]
    public string MaQuyetDinh { get; set; } = string.Empty;

    public Guid NhanSuId { get; set; }

    public LoaiKhenThuongKyLuat Loai { get; set; }

    [MaxLength(200)]
    public string HinhThuc { get; set; } = string.Empty;

    public decimal? SoTien { get; set; }

    [MaxLength(500)]
    public string LyDo { get; set; } = string.Empty;

    public DateTime NgayQuyetDinh { get; set; }

    public DateTime? NgayHieuLuc { get; set; }

    public TrangThaiKhenThuongKyLuat TrangThai { get; set; } = TrangThaiKhenThuongKyLuat.ChoDuyet;

    public string? NguoiDuyet { get; set; }

    public DateTime? NgayDuyet { get; set; }

    public string? GhiChu { get; set; }

    public string? TepDinhKem { get; set; }

    // Navigation properties
    public virtual NhanSu? NhanSu { get; set; }
}
