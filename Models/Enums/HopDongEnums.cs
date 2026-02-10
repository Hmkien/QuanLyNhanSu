using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

/// <summary>
/// Trạng thái hợp đồng
/// </summary>
public enum TrangThaiHopDong
{
    [Description("Hiệu lực")]
    HieuLuc,
    
    [Description("Hết hạn")]
    HetHan,
    
    [Description("Chấm dứt")]
    ChamDut
}

/// <summary>
/// Loại hợp đồng
/// </summary>
public enum LoaiHopDong
{
    [Description("Thử việc")]
    ThuViec,
    
    [Description("Có thời hạn")]
    CoThoiHan,
    
    [Description("Không thời hạn")]
    KhongThoiHan
}
