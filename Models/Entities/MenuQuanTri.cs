using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanLuc.Models.Entities;
public class MenuQuanTri : EntityBase
{
    [Display(Name = "Tên menu")]
    public string TenMenu { get; set; } = string.Empty;
    [Display(Name = "Vị trí")]
    public int ViTri { get; set; }
    [Display(Name = "Icon")]
    public string? IconClass { get; set; }
    [Display(Name = "Đường dẫn")]
    public string? DuongDan { get; set; } 
    [Display(Name = "Menu cha")]
    public Guid? ParentId { get; set; }
    public virtual MenuQuanTri? ParentMenu { get; set; }
    public virtual ICollection<MenuQuanTri> SubMenus { get; set; } = new List<MenuQuanTri>();
    public bool IsParent => ParentId == null;
    [Display(Name = "Controller")]
    public string? ControllerName { get; set; } 
    [Display(Name = "Action")]
    public string? ActionName { get; set; }
    [Display(Name = "Area")]
    public string? Area { get; set; }
}
