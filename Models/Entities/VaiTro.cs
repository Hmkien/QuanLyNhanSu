using Microsoft.AspNetCore.Identity;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models.Entities
{
    public class VaiTro : IdentityRole
    {
        public string? RoleCode { get; set; }
        public Status Status { get; set; } = Status.Approved;
    }
}