using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Controllers
{
    public class QuanTriHeThongController : Controller
    {
        private readonly QLNLContext _context;

        public QuanTriHeThongController(QLNLContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rootMenus = await _context.MenuQuanTris
                .Where(m => m.ParentId == null)
                .OrderBy(m => m.ViTri)
                .ToListAsync();
            var allMenus = await _context.MenuQuanTris.ToListAsync();
            BuildMenuTree(rootMenus, allMenus);

            return View(rootMenus);
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
        public IActionResult Create()
        {
            var parentMenus = _context.MenuQuanTris
                    .Where(m => m.ParentId == null)
                    .ToList();
            var menuQuantri = new MenuQuanTri();
            ViewBag.ParentMenu = new SelectList(parentMenus, "Id", "TenMenu");
            return View();
        }

        // POST: MenuQuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenMenu,ViTri,IconClass,DuongDan ,ControllerName,ActionName,Area,ParentId,Id,Status,Created")] MenuQuanTri menuQuanTri)
        {
            if (ModelState.IsValid)
            {
                menuQuanTri.Id = Guid.NewGuid();
                _context.Add(menuQuanTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuQuanTri);
        }

        // GET: MenuQuanTris/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuQuanTri = await _context.MenuQuanTris.FindAsync(id);
            if (menuQuanTri == null)
            {
                return NotFound();
            }
             var parentMenus = _context.MenuQuanTris
                    .Where(m => m.ParentId == null)
                    .ToList();
            var menuQuantri = new MenuQuanTri();
            ViewBag.ParentMenu = new SelectList(parentMenus, "Id", "TenMenu",menuQuanTri.ParentId);
            return View(menuQuanTri);
        }

        // POST: MenuQuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TenMenu,ViTri,IconClass,DuongDan,ControllerName,ActionName,Area,ParentId,Id,Status,Created")] MenuQuanTri menuQuanTri)
        {
            if (id != menuQuanTri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuQuanTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuQuanTriExists(menuQuanTri.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
             var parentMenus = _context.MenuQuanTris
                    .Where(m => m.ParentId == null)
                    .ToList();
            var menuQuantri = new MenuQuanTri();
            ViewBag.ParentMenu = new SelectList(parentMenus, "Id", "TenMenu",menuQuanTri.ParentId);
            return View(menuQuanTri);
        }

        // GET: MenuQuanTris/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuQuanTri = await _context.MenuQuanTris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuQuanTri == null)
            {
                return NotFound();
            }

            return View(menuQuanTri);
        }

        // POST: MenuQuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var menuQuanTri = await _context.MenuQuanTris.FindAsync(id);
            if (menuQuanTri != null)
            {
                _context.MenuQuanTris.Remove(menuQuanTri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuQuanTriExists(Guid id)
        {
            return _context.MenuQuanTris.Any(e => e.Id == id);
        }
    }
}
