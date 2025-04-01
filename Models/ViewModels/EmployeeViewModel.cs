using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.ViewModels;

public class EmployeeViewModel
{
    public string HoVaTen { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public string CCCD { get; set; } = string.Empty;
    public Guid? PhongBanId { get; set; }
    public Guid? ChucVuId { get; set; }
    public NhanSuType LoaiNhanSu { get; set; }
    public string Email { get; set; } = string.Empty;
    public string SoDienThoai { get; set; } = string.Empty;
    public string MatKhau { get; set; } = string.Empty;
    public string XacNhanMatKhau { get; set; } = string.Empty;
    public IFormFile? AnhDaiDien { get; set; }
    public string MaNhanVien { get; set; } = string.Empty;

}
