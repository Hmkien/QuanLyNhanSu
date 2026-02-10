using System.ComponentModel.DataAnnotations;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.ViewModels;

public class ThuTucHanhChinhVM
{
    public Guid Id { get; set; }
    
    [Display(Name = "Mã thủ tục")]
    public string MaThuTuc { get; set; } = string.Empty;
    
    public Guid NhanSuId { get; set; }
    
    [Display(Name = "Mã nhân viên")]
    public string MaNhanVien { get; set; } = string.Empty;
    
    [Display(Name = "Họ tên")]
    public string HoTen { get; set; } = string.Empty;
    
    [Display(Name = "Phòng ban")]
    public string PhongBan { get; set; } = string.Empty;
    
    [Display(Name = "Loại thủ tục")]
    [Required(ErrorMessage = "Vui lòng chọn loại thủ tục")]
    public LoaiThuTuc LoaiThuTuc { get; set; }
    
    [Display(Name = "Lý do")]
    [Required(ErrorMessage = "Vui lòng nhập lý do")]
    public string LyDo { get; set; } = string.Empty;
    
    [Display(Name = "Ngày nộp")]
    [DataType(DataType.Date)]
    public DateTime NgayNop { get; set; }
    
    [Display(Name = "Ngày bắt đầu")]
    [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
    [DataType(DataType.Date)]
    public DateTime NgayBatDau { get; set; }
    
    [Display(Name = "Ngày kết thúc")]
    [DataType(DataType.Date)]
    public DateTime? NgayKetThuc { get; set; }
    
    [Display(Name = "Số ngày")]
    public decimal? SoNgay { get; set; }
    
    [Display(Name = "Trạng thái")]
    public TrangThaiThuTuc TrangThai { get; set; } = TrangThaiThuTuc.NopDon;
    
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
