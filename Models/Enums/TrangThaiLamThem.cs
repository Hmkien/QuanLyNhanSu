using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

public enum TrangThaiLamThem
{
    [Description("Chưa duyệt")]
    ChuaDuyet = 1,
    [Description("Đã duyệt")]
    DaDuyet = 2,
    [Description("Từ chối")]
    TuChoi = 3
} 