using Microsoft.AspNetCore.Identity;

namespace QuanLyNhanLuc.Models.Entities;

public class NguoiDung : IdentityUser
{
    public string MaNhanVien { get; set; } = string.Empty;
    public bool isSuperAdmin { get; set; } = false;
    public virtual ThongTinNguoiDung? ThongTinNguoiDung { get; set; }
}
