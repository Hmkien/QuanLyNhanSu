using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanLuc.Models.Entities;

public class BaoHiem
{
    public int Id { get; set; }
    public int NhanSuId { get; set; }
    
    // Bảo hiểm xã hội
    [MaxLength(13)]
    public string SoBHXH { get; set; } = null!;
    [MaxLength(13)]
    public string? SoBHXHCu { get; set; }
    public DateTime NgayThamGia { get; set; }
    public string NoiDangKyBHXH { get; set; } = null!;
    public DateTime NgayNhanSoBHXH { get; set; }
    public DateTime NgayCap { get; set; }
    public DateTime NgayTraSoBHXH { get; set; }

    // Bảo hiểm thất nghiệp
    public DateTime NgayThamGiaBHTN { get; set; }
    public int ThoiGianDongBHTN { get; set; } // Số tháng

    // Bảo hiểm y tế
    [MaxLength(15)]
    public string SoBHYT { get; set; } = null!;
    public DateTime NgayCapThe { get; set; }
    public DateTime NgayHetHan { get; set; }
    public string NoiDangKyKCB { get; set; } = null!;
    public string MaKCB { get; set; } = null!;
    public string MaTinhBenhVien { get; set; } = null!;
    public bool DaTraTheBHYT { get; set; }

    // Navigation properties
    public virtual NhanSu NhanSu { get; set; } = null!;
} 