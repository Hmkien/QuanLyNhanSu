using System.ComponentModel.DataAnnotations;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class ChamCong
{
    public int Id { get; set; }
    public int NhanSuId { get; set; }
    public DateTime NgayChamCong { get; set; }
    public TimeSpan GioVao { get; set; }
    public TimeSpan GioRa { get; set; }
    public TrangThaiChamCong TrangThai { get; set; }
    public string? GhiChu { get; set; }

    public virtual NhanSu NhanSu { get; set; } = null!;
} 