namespace QuanLyNhanLuc.Models.Entities;

public class DaoTao : EntityBase
{
    public string? NguoiDungId { get; set; }
    public virtual NguoiDung? NguoiDung { get; set; }

    public string? TenTruongToChuc { get; set; }
    public string? NganhHocTenLop { get; set; }
    public DateTime? ThoiGianBatDau { get; set; }
    public DateTime? ThoiGianKetThuc { get; set; }
    public string? HinhThucHoc { get; set; }
    public string? VanBangChungChi { get; set; }
}
