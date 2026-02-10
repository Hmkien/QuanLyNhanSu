using System;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.ViewModels;

public class DiemDanhVM
{
    public bool DaDiemDanhDen { get; set; }
    public bool DaDiemDanhVe { get; set; }
    public DateTime? GioDen { get; set; }
    public DateTime? GioVe { get; set; }
    public TrangThaiDiemDanh TrangThai { get; set; }
    public string TrangThaiText { get; set; } = string.Empty;
    public string TrangThaiClass { get; set; } = string.Empty;
    public TimeSpan? ThoiGianLamViec { get; set; }
    public string ThoiGianLamViecText { get; set; } = string.Empty;
    public bool CoTheDiemDanh { get; set; }
    public string ThongBao { get; set; } = string.Empty;
} 