using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Extensions;

public static class ThuTucExtensions
{
    /// <summary>
    /// Lấy CSS class cho badge trạng thái
    /// </summary>
    public static string GetStatusBadgeClass(this TrangThaiThuTuc trangThai)
    {
        return trangThai switch
        {
            TrangThaiThuTuc.NopDon => "status-badge status-nopdon",
            TrangThaiThuTuc.TruongPhongDuyet => "status-badge status-truongphong",
            TrangThaiThuTuc.KeToanDuyet => "status-badge status-ketoan",
            TrangThaiThuTuc.GiamDocDuyet => "status-badge status-giamdoc",
            TrangThaiThuTuc.HoanThanh => "status-badge status-hoanthanh",
            TrangThaiThuTuc.TuChoi => "status-badge status-tuchoi",
            _ => "status-badge"
        };
    }

    /// <summary>
    /// Lấy icon cho loại thủ tục
    /// </summary>
    public static string GetLoaiThuTucIcon(this LoaiThuTuc loaiThuTuc)
    {
        return loaiThuTuc switch
        {
            LoaiThuTuc.NghiPhep => "bi bi-calendar-x",
            LoaiThuTuc.LamOnsite => "bi bi-building",
            LoaiThuTuc.HoiCo => "bi bi-clock-history",
            LoaiThuTuc.Khac => "bi bi-file-text",
            _ => "bi bi-file-earmark"
        };
    }

    /// <summary>
    /// Lấy màu cho loại thủ tục
    /// </summary>
    public static string GetLoaiThuTucColor(this LoaiThuTuc loaiThuTuc)
    {
        return loaiThuTuc switch
        {
            LoaiThuTuc.NghiPhep => "text-warning",
            LoaiThuTuc.LamOnsite => "text-info",
            LoaiThuTuc.HoiCo => "text-danger",
            LoaiThuTuc.Khac => "text-secondary",
            _ => "text-primary"
        };
    }

    /// <summary>
    /// Lấy icon trạng thái
    /// </summary>
    public static string GetStatusIcon(this TrangThaiThuTuc trangThai)
    {
        return trangThai switch
        {
            TrangThaiThuTuc.NopDon => "bi bi-file-earmark-arrow-up",
            TrangThaiThuTuc.TruongPhongDuyet => "bi bi-person-check",
            TrangThaiThuTuc.KeToanDuyet => "bi bi-calculator",
            TrangThaiThuTuc.GiamDocDuyet => "bi bi-person-badge",
            TrangThaiThuTuc.HoanThanh => "bi bi-check-circle-fill",
            TrangThaiThuTuc.TuChoi => "bi bi-x-circle-fill",
            _ => "bi bi-file-earmark"
        };
    }
}
