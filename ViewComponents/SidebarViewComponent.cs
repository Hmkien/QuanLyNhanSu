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
            string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<MenuQuanTri> menus = [];

            if (string.IsNullOrEmpty(userId))
            {
                return View("_NavPartial", menus);
            }

            NguoiDung? user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("_NavPartial", menus);
            }

            // If super admin, return full menu tree
            if (user.isSuperAdmin)
            {
                List<MenuQuanTri> rootMenus = await _context.MenuQuanTris
                    .Where(m => m.ParentId == null)
                    .OrderBy(m => m.ViTri)
                    .ToListAsync();
                List<MenuQuanTri> allMenus = await _context.MenuQuanTris.ToListAsync();
                BuildMenuTree(rootMenus, allMenus);
                menus = rootMenus;
                return View("_NavPartial", menus);
            }

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            string? roleName = userRoles.FirstOrDefault();
            if (string.IsNullOrEmpty(roleName))
            {
                return View("_NavPartial", menus);
            }

            VaiTro? roleEntity = await _context.VaiTros.FirstOrDefaultAsync(r => r.Name == roleName);
            if (roleEntity == null)
            {
                return View("_NavPartial", menus);
            }

            List<Guid> menuIds = await _context.VaiTroMenus
                 .Where(e => e.VaiTroId == roleEntity.Id)
                 .Select(r => r.MenuId)
                 .ToListAsync();

            if (!menuIds.Any())
            {
                return View("_NavPartial", menus);
            }

            List<MenuQuanTri> root = await _context.MenuQuanTris
                .Where(m => m.ParentId == null && menuIds.Contains(m.Id))
                .OrderBy(m => m.ViTri)
                .ToListAsync();
            List<MenuQuanTri> all = await _context.MenuQuanTris.Where(e => menuIds.Contains(e.Id)).ToListAsync();
            BuildMenuTree(root, all);
            menus = root;

            return View("_NavPartial", menus);
        }
        private void BuildMenuTree(List<MenuQuanTri> parentMenus, List<MenuQuanTri> allMenus)
        {
            foreach (MenuQuanTri menu in parentMenus)
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
