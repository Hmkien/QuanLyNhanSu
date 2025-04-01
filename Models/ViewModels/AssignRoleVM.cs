using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Models.ViewModels
{
    public class AssignRoleVM
    {
        public NguoiDung User { get; set; } = default!;
        public IList<VaiTro>? AllRole { get; set; } = new List<VaiTro>();
        public IList<string> SelectedRole { get; set; } = new List<string>();
    }
}