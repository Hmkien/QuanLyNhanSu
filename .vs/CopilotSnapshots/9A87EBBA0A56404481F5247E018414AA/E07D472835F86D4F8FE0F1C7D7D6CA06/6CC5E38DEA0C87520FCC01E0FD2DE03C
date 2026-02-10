using System.ComponentModel.DataAnnotations;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.ViewModels;

public class KhenThuongKyLuatVM
{
    public Guid Id { get; set; }
    
    [Display(Name = "Mã quyết định")]
    public string MaQuyetDinh { get; set; } = string.Empty;
    
    public Guid NhanSuId { get; set; }
    
    [Display(Name = "Mã nhân viên")]
    public string MaNhanVien { get; set; } = string.Empty;
    
    [Display(Name = "Họ tên")]
    public string HoTen { get; set; } = string.Empty;
    
    [Display(Name = "Phòng ban")]
    public string PhongBan { get; set; } = string.Empty;
    
    [Display(Name = "Loại")]
    [Required(ErrorMessage = "Vui lòng chọn loại")]
    public LoaiKhenThuongKyLuat Loai { get; set; }
    
    [Display(Name = "Hình thức")]
    [Required(ErrorMessage = "Vui lòng nhập hình thức")]
    public string HinhThuc { get; set; } = string.Empty;
    
    [Display(Name = "Số tiền")]
    [DisplayFormat(DataFormatString = "{0:N0}")]
    public decimal? SoTien { get; set; }
    
    [Display(Name = "Lý do")]
    [Required(ErrorMessage = "Vui lòng nhập lý do")]
    public string LyDo { get; set; } = string.Empty;
    
    [Display(Name = "Ngày quyết định")]
    [Required(ErrorMessage = "Vui lòng nhập ngày quyết định")]
    [DataType(DataType.Date)]
    public DateTime NgayQuyetDinh { get; set; }
    
    [Display(Name = "Ngày hiệu lực")]
    [DataType(DataType.Date)]
    public DateTime? NgayHieuLuc { get; set; }
    
    [Display(Name = "Trạng thái")]
    public TrangThaiKhenThuongKyLuat TrangThai { get; set; } = TrangThaiKhenThuongKyLuat.ChoDuyet;
    
    [Display(Name = "Người duyệt")]
    public string? NguoiDuyet { get; set; }
    
    [Display(Name = "Ngày duyệt")]
    [DataType(DataType.Date)]
    public DateTime? NgayDuyet { get; set; }
    
    [Display(Name = "Ghi chú")]
    public string? GhiChu { get; set; }
    
    [Display(Name = "Tệp đính kèm")]
    public string? TepDinhKem { get; set; }
}
