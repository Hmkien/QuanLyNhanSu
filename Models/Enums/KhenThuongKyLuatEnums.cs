using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

/// <summary>
/// Loại khen thưởng/kỷ luật
/// </summary>
public enum LoaiKhenThuongKyLuat
{
    [Description("Khen thưởng")]
    KhenThuong,
    
    [Description("Kỷ luật")]
    KyLuat
}

/// <summary>
/// Hình thức khen thưởng
/// </summary>
public enum HinhThucKhenThuong
{
    [Description("Thưởng tiền mặt")]
    ThuongTienMat,
    
    [Description("Bằng khen")]
    BangKhen,
    
    [Description("Giấy khen")]
    GiayKhen,
    
    [Description("Tăng lương")]
    TangLuong
}

/// <summary>
/// Hình thức kỷ luật
/// </summary>
public enum HinhThucKyLuat
{
    [Description("Nhắc nhở")]
    NhacNho,
    
    [Description("Cảnh cáo")]
    CanhCao,
    
    [Description("Phạt tiền")]
    PhatTien,
    
    [Description("Hạ bậc lương")]
    HaBacLuong,
    
    [Description("Sa thải")]
    SaThai
}

/// <summary>
/// Trạng thái khen thưởng/kỷ luật
/// </summary>
public enum TrangThaiKhenThuongKyLuat
{
    [Description("Chờ duyệt")]
    ChoDuyet,
    
    [Description("Đã duyệt")]
    DaDuyet,
    
    [Description("Từ chối")]
    TuChoi
}
