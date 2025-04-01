using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

public enum TrangThaiDiemDanh
{
    [Description("Đúng giờ")]
    DungGio = 0,
    [Description("Muộn")]
    Muon = 1,
    [Description("Sớm")]
    Som = 2
} 