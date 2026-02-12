using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly QLNLContext _context;

        public ChucVuController(QLNLContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search, int? status, int page = 1, int pageSize = 10)
        {
            IQueryable<ChucVu> query = _context.ChucVus.AsNoTracking().AsQueryable();

            // Tìm kiếm theo tên chức vụ
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.TenChucVu.Contains(search));
            }

            // Lọc theo trạng thái
            if (status.HasValue)
            {
                query = query.Where(x => (int)x.Status == status.Value);
            }

            query = query.OrderBy(x => x.TenChucVu);
            var total = await query.CountAsync();
            List<ChucVu> items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            ViewBag.TotalItems = total;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.Search = search;
            ViewBag.Status = status;

            return View(items);
        }

        // AJAX endpoints for modal operations
        [HttpGet]
        public async Task<IActionResult> GetChucVu(Guid id)
        {
            ChucVu? cv = await _context.ChucVus.FindAsync(id);
            return cv == null
                ? NotFound()
                : Json(new { id = cv.Id, chucVuCode = cv.ChucVuCode, ten = cv.TenChucVu, moTa = cv.MoTa, status = (int)cv.Status });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAjax([FromForm] string chucVuCode, [FromForm] string tenChucVu, [FromForm] string? moTa)
        {
            if (string.IsNullOrWhiteSpace(chucVuCode))
            {
                return Json(new { success = false, message = "Mã chức vụ không được để trống" });
            }

            if (string.IsNullOrWhiteSpace(tenChucVu))
            {
                return Json(new { success = false, message = "Tên chức vụ không được để trống" });
            }

            var exists = await _context.ChucVus.AnyAsync(x => x.ChucVuCode == chucVuCode);
            if (exists)
            {
                return Json(new { success = false, message = "Mã chức vụ đã tồn tại" });
            }

            var chucVu = new ChucVu
            {
                ChucVuCode = chucVuCode,
                TenChucVu = tenChucVu,
                MoTa = moTa ?? string.Empty,
                Status = Status.Pending
            };
            _ = _context.ChucVus.Add(chucVu);
            _ = await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> EditAjax([FromForm] Guid id, [FromForm] string chucVuCode, [FromForm] string tenChucVu, [FromForm] string? moTa)
        {
            ChucVu? cv = await _context.ChucVus.FindAsync(id);
            if (cv == null)
            {
                return Json(new { success = false, message = "Chức vụ không tồn tại" });
            }

            if (cv.Status == Status.Approved)
            {
                return Json(new { success = false, message = "Không thể sửa chức vụ đã được duyệt" });
            }

            if (string.IsNullOrWhiteSpace(chucVuCode))
            {
                return Json(new { success = false, message = "Mã chức vụ không được để trống" });
            }

            var exists = await _context.ChucVus.AnyAsync(x => x.ChucVuCode == chucVuCode && x.Id != id);
            if (exists)
            {
                return Json(new { success = false, message = "Mã chức vụ đã tồn tại" });
            }

            cv.ChucVuCode = chucVuCode;
            cv.TenChucVu = tenChucVu;
            cv.MoTa = moTa ?? string.Empty;
            _ = await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAjax([FromForm] Guid id)
        {
            ChucVu? cv = await _context.ChucVus.FindAsync(id);
            if (cv == null)
            {
                return Json(new { success = false, message = "Chức vụ không tồn tại" });
            }

            _ = _context.ChucVus.Remove(cv);
            _ = await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveAjax([FromForm] Guid id)
        {
            ChucVu? cv = await _context.ChucVus.FindAsync(id);
            if (cv == null)
            {
                return Json(new { success = false, message = "Chức vụ không tồn tại" });
            }

            cv.Status = Status.Approved;
            _ = await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> RejectAjax([FromForm] Guid id)
        {
            ChucVu? cv = await _context.ChucVus.FindAsync(id);
            if (cv == null)
            {
                return Json(new { success = false, message = "Chức vụ không tồn tại" });
            }

            cv.Status = Status.Rejected;
            _ = await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
