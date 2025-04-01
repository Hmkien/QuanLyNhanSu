using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.Entities;
using QuanLyNhanLuc.Models.ViewModels;

namespace QuanLyNhanLuc.Controllers;

public class BaoHiemController : Controller
{
    private readonly QLNLContext _context;

    public BaoHiemController(QLNLContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var baoHiems = await _context.BaoHiems
            .Include(b => b.NhanSu)
            .Select(b => new BaoHiemVM
            {
                Id = b.Id,
                MaNhanVien = b.NhanSu.MaNhanVien,
                HoTen = b.NhanSu.HoVaTen,
                PhongBan = b.NhanSu.PhongBan.TenPhongBan,
                SoBHXH = b.SoBHXH,
                SoBHXHCu = b.SoBHXHCu,
                SoBHYT = b.SoBHYT,
                NgayThamGia = b.NgayThamGia,
                NgayCapThe = b.NgayCapThe,
                NgayHetHan = b.NgayHetHan,
                NoiDangKyBHXH = b.NoiDangKyBHXH,
                NoiDangKyKCB = b.NoiDangKyKCB,
                MaKCB = b.MaKCB,
                MaTinhBenhVien = b.MaTinhBenhVien,
                DaTraTheBHYT = b.DaTraTheBHYT,
                NgayThamGiaBHTN = b.NgayThamGiaBHTN,
                ThoiGianDongBHTN = b.ThoiGianDongBHTN
            })
            .ToListAsync();

        return View(baoHiems);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baoHiem = await _context.BaoHiems
            .Include(b => b.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .Where(b => b.Id == id)
            .Select(b => new BaoHiemVM
            {
                Id = b.Id,
                MaNhanVien = b.NhanSu.MaNhanVien,
                HoTen = b.NhanSu.HoVaTen,
                PhongBan = b.NhanSu.PhongBan.TenPhongBan,
                SoBHXH = b.SoBHXH,
                SoBHXHCu = b.SoBHXHCu,
                SoBHYT = b.SoBHYT,
                NgayThamGia = b.NgayThamGia,
                NgayCapThe = b.NgayCapThe,
                NgayHetHan = b.NgayHetHan,
                NoiDangKyBHXH = b.NoiDangKyBHXH,
                NoiDangKyKCB = b.NoiDangKyKCB,
                MaKCB = b.MaKCB,
                MaTinhBenhVien = b.MaTinhBenhVien,
                DaTraTheBHYT = b.DaTraTheBHYT,
                NgayThamGiaBHTN = b.NgayThamGiaBHTN,
                ThoiGianDongBHTN = b.ThoiGianDongBHTN
            })
            .FirstOrDefaultAsync();

        if (baoHiem == null)
        {
            return NotFound();
        }

        return View(baoHiem);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BaoHiemVM model)
    {
        if (ModelState.IsValid)
        {
            var baoHiem = new BaoHiem
            {
                SoBHXH = model.SoBHXH,
                SoBHXHCu = model.SoBHXHCu,
                SoBHYT = model.SoBHYT,
                NgayThamGia = model.NgayThamGia,
                NgayCapThe = model.NgayCapThe,
                NgayHetHan = model.NgayHetHan,
                NoiDangKyBHXH = model.NoiDangKyBHXH,
                NoiDangKyKCB = model.NoiDangKyKCB,
                MaKCB = model.MaKCB,
                MaTinhBenhVien = model.MaTinhBenhVien,
                DaTraTheBHYT = model.DaTraTheBHYT,
                NgayThamGiaBHTN = model.NgayThamGiaBHTN,
                ThoiGianDongBHTN = model.ThoiGianDongBHTN
            };

            _context.Add(baoHiem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baoHiem = await _context.BaoHiems
            .Include(b => b.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .Where(b => b.Id == id)
            .Select(b => new BaoHiemVM
            {
                Id = b.Id,
                MaNhanVien = b.NhanSu.MaNhanVien,
                HoTen = b.NhanSu.HoVaTen,
                PhongBan = b.NhanSu.PhongBan.TenPhongBan,
                SoBHXH = b.SoBHXH,
                SoBHXHCu = b.SoBHXHCu,
                SoBHYT = b.SoBHYT,
                NgayThamGia = b.NgayThamGia,
                NgayCapThe = b.NgayCapThe,
                NgayHetHan = b.NgayHetHan,
                NoiDangKyBHXH = b.NoiDangKyBHXH,
                NoiDangKyKCB = b.NoiDangKyKCB,
                MaKCB = b.MaKCB,
                MaTinhBenhVien = b.MaTinhBenhVien,
                DaTraTheBHYT = b.DaTraTheBHYT,
                NgayThamGiaBHTN = b.NgayThamGiaBHTN,
                ThoiGianDongBHTN = b.ThoiGianDongBHTN
            })
            .FirstOrDefaultAsync();

        if (baoHiem == null)
        {
            return NotFound();
        }

        return View(baoHiem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BaoHiemVM model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var baoHiem = await _context.BaoHiems.FindAsync(id);
                if (baoHiem == null)
                {
                    return NotFound();
                }

                baoHiem.SoBHXH = model.SoBHXH;
                baoHiem.SoBHXHCu = model.SoBHXHCu;
                baoHiem.SoBHYT = model.SoBHYT;
                baoHiem.NgayThamGia = model.NgayThamGia;
                baoHiem.NgayCapThe = model.NgayCapThe;
                baoHiem.NgayHetHan = model.NgayHetHan;
                baoHiem.NoiDangKyBHXH = model.NoiDangKyBHXH;
                baoHiem.NoiDangKyKCB = model.NoiDangKyKCB;
                baoHiem.MaKCB = model.MaKCB;
                baoHiem.MaTinhBenhVien = model.MaTinhBenhVien;
                baoHiem.DaTraTheBHYT = model.DaTraTheBHYT;
                baoHiem.NgayThamGiaBHTN = model.NgayThamGiaBHTN;
                baoHiem.ThoiGianDongBHTN = model.ThoiGianDongBHTN;

                _context.Update(baoHiem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaoHiemExists(model.Id))
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
        return View(model);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baoHiem = await _context.BaoHiems
            .Include(b => b.NhanSu)
            .ThenInclude(n => n.PhongBan)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (baoHiem == null)
        {
            return NotFound();
        }

        return View(baoHiem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var baoHiem = await _context.BaoHiems.FindAsync(id);
        if (baoHiem != null)
        {
            _context.BaoHiems.Remove(baoHiem);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool BaoHiemExists(int id)
    {
        return _context.BaoHiems.Any(e => e.Id == id);
    }
} 