using System;

namespace QuanLyNhanLuc.Models;

public class TuyenDung
{
    public Guid Id { get; set; }
    public string ViTri { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public string YeuCau { get; set; } = string.Empty;
    public string TrangThai { get; set; } = string.Empty;
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public DateTime? NgayHetHan { get; set; }
} 