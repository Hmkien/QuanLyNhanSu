using System;

namespace QuanLyNhanLuc.Models;

public class NhanVien
{
    public Guid Id { get; set; }
    public string HoTen { get; set; }
    public string GioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public DateTime NgayVaoLam { get; set; }
    public string TrangThai { get; set; }
    public Guid PhongBanId { get; set; }
    public PhongBan PhongBan { get; set; }
} 