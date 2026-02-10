using System;

namespace QuanLyNhanLuc.Models;

public class ThuTuc : EntityBase
{
    public string TenThuTuc { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public string TrangThai { get; set; } = string.Empty;
    public DateTime NgayTao { get; set; }
    public DateTime? NgayDuyet { get; set; }
    public Guid NhanVienId { get; set; }
    public NhanVien NhanVien { get; set; } = null!;
} 
