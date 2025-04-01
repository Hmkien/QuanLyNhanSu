using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

public enum TrangThaiChamCong
{
    [Description("Đi làm")]
    DiLam = 1,
    [Description("Nghỉ phép")]
    NghiPhep = 2,
    [Description("Nghỉ không phép")]
    NghiKhongPhep = 3,
    [Description("Đi muộn")]
    DiMuon = 4,
    [Description("Về sớm")]
    VeSom = 5
} 