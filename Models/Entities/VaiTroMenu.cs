namespace QuanLyNhanLuc.Models.Entities;

public class VaiTroMenu
{
    public string VaiTroId { get; set; } = string.Empty;
    public Guid MenuId { get; set; }

    public VaiTro VaiTro { get; set; } = default!;
    public MenuQuanTri Menu { get; set; } = default!;
}
