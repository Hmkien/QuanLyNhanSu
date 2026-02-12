using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Constants;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Controllers;

[Authorize(Policy = PolicyNames.QuanLyNhanSu)]
public class PhongBanController : Controller
{
    private readonly QLNLContext _context;

    public PhongBanController(QLNLContext context)
    {
        _context = context;
    }

    // GET: PhongBan
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? search = null, string? sortBy = null, string? sortOrder = "asc")
    {
        IQueryable<PhongBan> query = _context.PhongBans.AsQueryable();

        // Search
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.TenPhongBan.Contains(search) ||
                                     (p.MaPhongBan != null && p.MaPhongBan.Contains(search)));
        }

        // Sorting
        query = sortBy?.ToLower() switch
        {
            "name" => sortOrder == "desc" ? query.OrderByDescending(p => p.TenPhongBan) : query.OrderBy(p => p.TenPhongBan),
            "code" => sortOrder == "desc" ? query.OrderByDescending(p => p.MaPhongBan) : query.OrderBy(p => p.MaPhongBan),
            "status" => sortOrder == "desc" ? query.OrderByDescending(p => p.Status) : query.OrderBy(p => p.Status),
            _ => query.OrderByDescending(p => p.Created)
        };

        int total = await query.CountAsync();

        var phongBans = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new
            {
                p.Id,
                p.MaPhongBan,
                p.TenPhongBan,
                p.MoTa,
                p.Status,
                p.Created,
                SoLuongNhanVien = p.ThongTinNguoiDungs.Count,
                SoLuongNhanSuChinhThuc = p.NhanSus.Count
            })
            .ToListAsync();

        ViewBag.TotalPages = total > 0 ? (int)Math.Ceiling(total / (double)pageSize) : 1;
        ViewBag.TotalItems = total;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.Search = search;
        ViewBag.SortBy = sortBy;
        ViewBag.SortOrder = sortOrder;

        return View(phongBans);
    }

    // GET: PhongBan/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        PhongBan? phongBan = await _context.PhongBans
            .Include(p => p.ThongTinNguoiDungs)
                .ThenInclude(t => t.User)
            .Include(p => p.NhanSus)
            .FirstOrDefaultAsync(p => p.Id == id);

        return phongBan == null ? NotFound() : View(phongBan);
    }

    // GET: PhongBan/GetModalThemPhongBan
    public IActionResult GetModalThemPhongBan()
    {
        return PartialView("~/Views/Modals/_ModalThemPhongBan.cshtml");
    }

    // POST: PhongBan/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string MaPhongBan, string TenPhongBan, string? MoTa)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(TenPhongBan))
            {
                return Json(new { success = false, message = "Tên phòng ban không được để trống" });
            }

            if (string.IsNullOrWhiteSpace(MaPhongBan))
            {
                return Json(new { success = false, message = "Mã phòng ban không được để trống" });
            }

            // Check duplicate code
            bool isDuplicate = await _context.PhongBans.AnyAsync(p => p.MaPhongBan == MaPhongBan);
            if (isDuplicate)
            {
                return Json(new { success = false, message = "Mã phòng ban đã tồn tại" });
            }

            PhongBan phongBan = new()
            {
                MaPhongBan = MaPhongBan,
                TenPhongBan = TenPhongBan,
                MoTa = MoTa ?? string.Empty,
                Status = Status.Pending
            };

            _ = _context.PhongBans.Add(phongBan);
            _ = await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Thêm phòng ban thành công" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
        }
    }

    // GET: PhongBan/GetModalSuaPhongBan/5
    public async Task<IActionResult> GetModalSuaPhongBan(Guid id)
    {
        PhongBan? phongBan = await _context.PhongBans.FindAsync(id);
        return phongBan == null ? NotFound() : PartialView("~/Views/Modals/_ModalSuaPhongBan.cshtml", phongBan);
    }

    // POST: PhongBan/Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Guid Id, string MaPhongBan, string TenPhongBan, string? MoTa)
    {
        try
        {
            PhongBan? phongBan = await _context.PhongBans.FindAsync(Id);
            if (phongBan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy phòng ban" });
            }

            if (string.IsNullOrWhiteSpace(TenPhongBan))
            {
                return Json(new { success = false, message = "Tên phòng ban không được để trống" });
            }

            if (string.IsNullOrWhiteSpace(MaPhongBan))
            {
                return Json(new { success = false, message = "Mã phòng ban không được để trống" });
            }

            // Check duplicate code (excluding current)
            bool isDuplicate = await _context.PhongBans
                .AnyAsync(p => p.MaPhongBan == MaPhongBan && p.Id != Id);
            if (isDuplicate)
            {
                return Json(new { success = false, message = "Mã phòng ban đã tồn tại" });
            }

            phongBan.MaPhongBan = MaPhongBan;
            phongBan.TenPhongBan = TenPhongBan;
            phongBan.MoTa = MoTa ?? string.Empty;

            _ = await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Cập nhật phòng ban thành công" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
        }
    }

    // POST: PhongBan/Approve
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(Guid id)
    {
        try
        {
            PhongBan? phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy phòng ban" });
            }

            phongBan.Status = Status.Approved;
            _ = await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Duyệt phòng ban thành công" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
        }
    }

    // POST: PhongBan/Cancel
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(Guid id)
    {
        try
        {
            PhongBan? phongBan = await _context.PhongBans.FindAsync(id);
            if (phongBan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy phòng ban" });
            }

            phongBan.Status = Status.Canceled;
            _ = await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Hủy duyệt phòng ban thành công" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
        }
    }

    // GET: PhongBan/GetModalXoaPhongBan/5
    public IActionResult GetModalXoaPhongBan(Guid id)
    {
        return PartialView("~/Views/Modals/_ModalXoaPhongBan.cshtml", id);
    }

    // POST: PhongBan/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            PhongBan? phongBan = await _context.PhongBans
                .Include(p => p.ThongTinNguoiDungs)
                .Include(p => p.NhanSus)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (phongBan == null)
            {
                return Json(new { success = false, message = "Không tìm thấy phòng ban" });
            }

            // Check if has employees
            if (phongBan.ThongTinNguoiDungs.Any() || phongBan.NhanSus.Any())
            {
                return Json(new { success = false, message = "Không thể xóa phòng ban đang có nhân viên" });
            }

            _ = _context.PhongBans.Remove(phongBan);
            _ = await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Xóa phòng ban thành công" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
        }
    }
}
