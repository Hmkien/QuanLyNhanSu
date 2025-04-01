using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class PhongBan
{
    public int Id { get; set; }
    public string TenPhongBan { get; set; }
    public string MaPhongBan { get; set; }
    public string MoTa { get; set; }
    public virtual ICollection<NhanSu> NhanSus { get; set; }
} 