using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities;

public class LichLamThem : EntityBase
{
    public Guid NhanSuId { get; set; }
    public DateTime NgayLamThem { get; set; }
    public TimeSpan GioBatDau { get; set; }
    public TimeSpan GioKetThuc { get; set; }
    public string LyDo { get; set; } = string.Empty;
    public TrangThaiLamThem TrangThai { get; set; }
    public string NguoiDuyet { get; set; } = string.Empty;

    public virtual NhanSu? NhanSu { get; set; }
}
