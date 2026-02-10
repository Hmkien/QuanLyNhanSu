using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;

public class PhanLoaiNhanSu : EntityBase
{
    public string PhanLoaiCode { get; set; } = string.Empty;
    [Display(Name = "Tên phân loại")]
    [Required(ErrorMessage = "Tên phân loại không được để trống")]
    public string TenPhanLoai { get; set; } = string.Empty;

    [Display(Name = "Mô tả")]
    public string? MoTa { get; set; }

}
