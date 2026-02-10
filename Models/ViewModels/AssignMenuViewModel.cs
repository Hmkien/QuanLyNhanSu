using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Models.ViewModels;
public class AssignMenuViewModel
{
    public VaiTro VaiTro { get; set; } = default!;
    public List<MenuQuanTri> MenuList { get; set; } = new List<MenuQuanTri>();
    public List<Guid> SelectedMenuIds { get; set; } = new List<Guid>();
}
