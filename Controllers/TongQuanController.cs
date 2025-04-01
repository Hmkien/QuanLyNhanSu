using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanLuc.Data;
using QuanLyNhanLuc.Models.ViewModels;
using QuanLyNhanLuc.Models.Enums;
using System;
using System.Linq;

namespace QuanLyNhanLuc.Controllers;
[Authorize]
public class TongQuanController : Controller
{
    private readonly QLNLContext _context;

    public TongQuanController(QLNLContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
         if (!User.IsInRole("Admin"))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();

    }
}
