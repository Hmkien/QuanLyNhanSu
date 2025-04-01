using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers
{
    public class VaiTroController : Controller
    {
        private readonly RoleManager<VaiTro> _roleManager;
        private readonly QLNLContext _context;
        public VaiTroController(RoleManager<VaiTro> roleManager, QLNLContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string Name)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    var role = new VaiTro { Name = Name };

                    await _roleManager.CreateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Name);

        }
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(string Id, string Name)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = Name;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string Id)
        {
            var Role = await _roleManager.FindByIdAsync(Id);
            if (Role != null)
            {
                await _roleManager.DeleteAsync(Role);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> AssignMenu(string id)
        {
            var vaiTro = await _context.VaiTros.FindAsync(id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            var menuList = await _context.MenuQuanTris.ToListAsync();
            var selectedList = await _context.VaiTroMenus.Where(vm => vm.VaiTroId == vaiTro.Id).Select(vm => vm.MenuId).ToListAsync();
            var model = new AssignMenuViewModel
            {
                VaiTro = vaiTro,
                MenuList = menuList,
                SelectedMenuIds = selectedList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignMenu(AssignMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vaiTro = await _context.VaiTros.FindAsync(model.VaiTro.Id);
                if (vaiTro == null)
                {
                    return NotFound();
                }

                var existingMenus = _context.VaiTroMenus.Where(vm => vm.VaiTroId == vaiTro.Id);
                _context.VaiTroMenus.RemoveRange(existingMenus);
                if (model.SelectedMenuIds != null)
                {
                    foreach (var menuId in model.SelectedMenuIds)
                    {
                        _context.VaiTroMenus.Add(new VaiTroMenu { VaiTroId = vaiTro.Id, MenuId = menuId });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.MenuList = await _context.MenuQuanTris.ToListAsync();
            return View(model);
        }

       
    }
}