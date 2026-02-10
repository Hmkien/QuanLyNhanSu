using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using System.Security.Claims;

namespace QuanLyNhanLuc.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly UserManager<NguoiDung> _userManager;
        private readonly QLNLContext _context;

        public SidebarViewComponent(UserManager<NguoiDung> userManager, QLNLContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<MenuQuanTri> menus = new List<MenuQuanTri>();

            if (userId is not null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var roleEntity = await _context.VaiTros.FirstOrDefaultAsync(r => r.Name == userRoles.FirstOrDefault());
                    var menuIds = await _context.VaiTroMenus
                         .Where(e => e.VaiTroId == roleEntity.Id)
                         .Select(r => r.MenuId)
                         .ToListAsync();
                    var rootMenus = await _context.MenuQuanTris
                        .Where(m => m.ParentId == null && menuIds.Contains(m.Id))
                        .OrderBy(m => m.ViTri)
                        .ToListAsync();
                    var allMenus = await _context.MenuQuanTris.Where(e => menuIds.Contains(e.Id)).ToListAsync();
                    BuildMenuTree(rootMenus, allMenus);
                    menus = rootMenus;
                }
            }

            return View("_NavPartial", menus);
        }
        private void BuildMenuTree(List<MenuQuanTri> parentMenus, List<MenuQuanTri> allMenus)
        {
            foreach (var menu in parentMenus)
            {
                menu.SubMenus = allMenus
                    .Where(m => m.ParentId == menu.Id)
                    .OrderBy(m => m.ViTri)
                    .ToList();
                if (menu.SubMenus.Any())
                {
                    BuildMenuTree(menu.SubMenus.ToList(), allMenus);
                }
            }
        }


    }
}
