using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly UserManager<NguoiDung> _userManager;
        private readonly RoleManager<VaiTro> _roleManager;
        private readonly QLNLContext _context;
        public TaiKhoanController(UserManager<NguoiDung> userManager, RoleManager<VaiTro> roleManager, QLNLContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> DanhSachTaiKhoan()
        {
            var accountList = await _userManager.Users.ToListAsync();
            return View(accountList);
        }

        public async Task<IActionResult> PhanQuyen(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var UserRole = await _userManager.GetRolesAsync(user);
            var AllRole = await _roleManager.Roles.Select(r => new VaiTro { Id = r.Id, Name = r.Name }).ToListAsync();
            var ViewModel = new AssignRoleVM
            {
                User = user,
                AllRole = AllRole,
                SelectedRole = UserRole
            };
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> PhanQuyen(AssignRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.User.Id);
                if (user == null)
                {
                    return NotFound();
                }

                var userRole = await _userManager.GetRolesAsync(user);

                foreach (var role in model.SelectedRole)
                {
                    var roleExist = await _context.VaiTros.Where(e => e.Name == role).FirstOrDefaultAsync();
                    if (roleExist is null)
                    {
                        ModelState.AddModelError(string.Empty, $"Role '{role}' does not exist.");
                        return View(model);
                    }

                    if (!userRole.Contains(role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }

                foreach (var role in userRole)
                {
                    if (!model.SelectedRole.Contains(role))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }

                return RedirectToAction(nameof(DanhSachTaiKhoan));
            }

            return View(model);
        }


    }
}