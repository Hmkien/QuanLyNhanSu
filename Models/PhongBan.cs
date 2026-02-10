using System;
using System.Collections.Generic;

namespace QuanLyNhanLuc.Models;

public class PhongBan : EntityBase
{
    public string TenPhongBan { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
} 
