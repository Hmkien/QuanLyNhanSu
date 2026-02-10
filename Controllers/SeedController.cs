using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using System.Security.Claims;

namespace QuanLyNhanLuc.Controllers
{
    [Authorize]
    [Route("seed")]
    public class SeedController : Controller
    {
        private readonly QLNLContext _context;

        public SeedController(QLNLContext context)
        {
            _context = context;
        }

        // POST /seed/run
        [HttpPost("run")]
        public async Task<IActionResult> Run()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Forbid();
            }

            NguoiDung? user = await _context.Users.FindAsync(userId);
            if (user == null || user.isSuperAdmin != true)
            {
                return Forbid();
            }

            try
            {
                await DbInitializer.SeedAsync(HttpContext.RequestServices);
                return Json(new { success = true, message = "Seeding completed" });
            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
