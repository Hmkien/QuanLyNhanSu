using QuanLyNhanLuc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class BaoHiem : EntityBase
{
    public Guid NhanSuId { get; set; }

    // Thông tin chung
    public LoaiBaoHiem LoaiBaoHiem { get; set; } = LoaiBaoHiem.BHXH;
    public TrangThaiBaoHiem TrangThaiBaoHiem { get; set; } = TrangThaiBaoHiem.ChuaThamGia;

    // Bảo hiểm xã hội
    [MaxLength(13)]
    public string SoBHXH { get; set; } = string.Empty;
    [MaxLength(13)]
    public string? SoBHXHCu { get; set; }
    public DateTime NgayThamGia { get; set; }
    public string NoiDangKyBHXH { get; set; } = string.Empty;
    public DateTime NgayNhanSoBHXH { get; set; }
    public DateTime NgayCap { get; set; }
    public DateTime NgayTraSoBHXH { get; set; }

    // Bảo hiểm thất nghiệp
    public DateTime NgayThamGiaBHTN { get; set; }
    public int ThoiGianDongBHTN { get; set; } // Số tháng

    // Bảo hiểm y tế
    [MaxLength(15)]
    public string SoBHYT { get; set; } = string.Empty;
    public DateTime NgayCapThe { get; set; }
    public DateTime NgayHetHan { get; set; }
    public string NoiDangKyKCB { get; set; } = string.Empty;
    public string MaKCB { get; set; } = string.Empty;
    public string MaTinhBenhVien { get; set; } = string.Empty;
    public bool DaTraTheBHYT { get; set; }

    // Navigation properties
    public virtual NhanSu? NhanSu { get; set; }
}
