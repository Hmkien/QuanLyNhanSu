using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

/// <summary>
/// Lo?i b?o hi?m
/// </summary>
public enum LoaiBaoHiem
{
    [Description("B?o hi?m xã h?i")]
    BHXH = 0,
    
    [Description("B?o hi?m y t?")]
    BHYT = 1,
    
    [Description("B?o hi?m th?t nghi?p")]
    BHTN = 2
}

/// <summary>
/// Tr?ng thái tham gia b?o hi?m
/// </summary>
public enum TrangThaiBaoHiem
{
    [Description("Ch?a tham gia")]
    ChuaThamGia = 0,
    
    [Description("?ang tham gia")]
    DangThamGia = 1,
    
    [Description("?ã ng?ng")]
    DaNgung = 2,
    
    [Description("T?m d?ng")]
    TamDung = 3
}
