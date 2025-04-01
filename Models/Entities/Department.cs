using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class Department : EntityBase
{
    [Display(Name = "Tên phòng ban")]
    public string TenPhongBan { get; set; } = string.Empty;
    [Display(Name = "Mô tả")]
    public string? MoTa { get; set; }
    public virtual ICollection<ThongTinNguoiDung> NhanSus { get; set; } = new List<ThongTinNguoiDung>();
}
