using System;
using System.Collections.Generic;

namespace QuanLyNhanLuc.Models;

public class PhongBan
{
    public Guid Id { get; set; }
    public string TenPhongBan { get; set; }
    public string MoTa { get; set; }
    public ICollection<NhanVien> NhanViens { get; set; }
} 