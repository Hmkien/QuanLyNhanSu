using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Controllers;

public class MenuController : Controller
{
    private readonly UserManager<NguoiDung> _userManager;

    public MenuController(UserManager<NguoiDung> userManager, QLNLContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    private readonly QLNLContext _context;

    public async Task<IActionResult> RenderSidebar()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        List<MenuQuanTri> menus;

        if (string.IsNullOrEmpty(userId) || !User.Identity.IsAuthenticated)
        {
            menus = new List<MenuQuanTri>();
        }
        else
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                menus = new List<MenuQuanTri>();
            }
            else
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                menus = await _context.VaiTroMenus
                .Where(vm => userRoles.Contains(vm.VaiTroId))
                .Select(vm => vm.Menu)
                .OrderBy(m => m.ViTri)
                .ToListAsync();
            }
        }

        return PartialView("_NavPartial", menus);
    }
}
