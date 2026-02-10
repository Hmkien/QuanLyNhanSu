using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

/// <summary>
/// Trạng thái bảng lương
/// </summary>
public enum TrangThaiBangLuong
{
    [Description("Chưa duyệt")]
    ChuaDuyet,
    
    [Description("Đã duyệt")]
    DaDuyet,
    
    [Description("Đã thanh toán")]
    DaThanhToan
}
