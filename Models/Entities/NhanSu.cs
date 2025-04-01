using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class NhanSu
{
    public int Id { get; set; }
    public string MaNhanVien { get; set; }
    public string HoVaTen { get; set; }
    public int PhongBanId { get; set; }
    public virtual PhongBan PhongBan { get; set; }
    public virtual ICollection<ChamCong> ChamCongs { get; set; }
    public virtual ICollection<LichLamThem> LichLamThems { get; set; }
} 