using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class ThongTinNguoiDung : EntityBase
{
    public string FullName { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; }
    public string GioiTinhStxt { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
    public Guid? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
    public Guid? ChucVuId { get; set; }
    public virtual ChucVu? ChucVu { get; set; }
    public NhanSuType? NhanSuType { get; set; }
    public string? NhanSuTypeStxt { get; set; }
    public string IdentityNumber { get; set; } = string.Empty;
    public string ImageLink { get; set; } = "/Image/AvatarMIG.png";
    public string? UserId { get; set; }
    public virtual NguoiDung? User { get; set; }
}
