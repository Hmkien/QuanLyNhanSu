using QuanLyNhanLuc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class HopDong : EntityBase
{
    [MaxLength(50)]
    public string MaHopDong { get; set; } = string.Empty;

    public Guid NhanSuId { get; set; }

    public LoaiHopDong LoaiHopDong { get; set; } = LoaiHopDong.ThuViec;

    public DateTime NgayKy { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public decimal LuongCoBan { get; set; }

    public string? GhiChu { get; set; }

    public TrangThaiHopDong TrangThai { get; set; } = TrangThaiHopDong.HieuLuc;

    public string? TepDinhKem { get; set; }

    // Navigation properties
    public virtual NhanSu? NhanSu { get; set; }
}
