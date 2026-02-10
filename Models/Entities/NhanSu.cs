namespace QuanLyNhanLuc.Models.Entities;

public class NhanSu : EntityBase
{
    public string MaNhanVien { get; set; } = string.Empty;
    public string HoVaTen { get; set; } = string.Empty;
    public Guid PhongBanId { get; set; }
    public virtual PhongBan PhongBan { get; set; } = null!;
    public virtual ICollection<ChamCong>? ChamCongs { get; set; }
    public virtual ICollection<LichLamThem>? LichLamThems { get; set; }
}
