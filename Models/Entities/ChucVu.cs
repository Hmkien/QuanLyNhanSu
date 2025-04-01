using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class ChucVu : EntityBase
{
    [Display(Name = "Tên chức vụ")]
    public string TenChucVu { get; set; } = string.Empty;
    [Display(Name = "Mô tả")]
    public string MoTa { get; set; } = string.Empty;

    public virtual ICollection<ThongTinNguoiDung> NhanSus { get; set; } = new List<ThongTinNguoiDung>();
}
