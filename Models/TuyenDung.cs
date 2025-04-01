using System;

namespace QuanLyNhanLuc.Models;

public class TuyenDung
{
    public Guid Id { get; set; }
    public string ViTri { get; set; }
    public string MoTa { get; set; }
    public string YeuCau { get; set; }
    public string TrangThai { get; set; }
    public DateTime NgayTao { get; set; }
    public DateTime? NgayHetHan { get; set; }
} 