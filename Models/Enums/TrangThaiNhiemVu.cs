using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

public enum TrangThaiNhiemVu
{
    [Description("Chưa bắt đầu")]
    ChuaBatDau = 0,
    [Description("Đang thực hiện")]
    DangThucHien = 1,
    [Description("Hoàn thành")]
    HoanThanh = 2
} 