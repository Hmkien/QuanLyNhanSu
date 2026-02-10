namespace QuanLyNhanLuc.Models.Entities;

public class TrinhDo : EntityBase
{
    public string? NguoiDungId { get; set; }
    public virtual NguoiDung? NguoiDung { get; set; }
    public string? TrinhDoHocVan { get; set; }
    public string? HocHamHocVi { get; set; }
    public string? LyLuanChinhTri { get; set; }
    public string? NgoaiNgu { get; set; }
}
