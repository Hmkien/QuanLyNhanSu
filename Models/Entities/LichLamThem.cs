using System.ComponentModel.DataAnnotations;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class LichLamThem
{
    public int Id { get; set; }
    public int NhanSuId { get; set; }
    public DateTime NgayLamThem { get; set; }
    public TimeSpan GioBatDau { get; set; }
    public TimeSpan GioKetThuc { get; set; }
    public string LyDo { get; set; } = null!;
    public TrangThaiLamThem TrangThai { get; set; }
    public string NguoiDuyet { get; set; } = null!;

    public virtual NhanSu NhanSu { get; set; } = null!;
} 