using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhanLuc.Controllers;

public class LuongController : Controller
{
    public IActionResult BangLuong()
    {
        return View();
    }
}
