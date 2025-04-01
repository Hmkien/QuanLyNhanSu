using System;

namespace QuanLyNhanLuc.Models;

public class ThuTuc
{
    public Guid Id { get; set; }
    public string TenThuTuc { get; set; }
    public string MoTa { get; set; }
    public string TrangThai { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime? NgayDuyet { get; set; }
    public Guid NhanVienId { get; set; }
    public NhanVien NhanVien { get; set; }
} 