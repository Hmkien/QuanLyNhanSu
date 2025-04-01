using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyNhanLuc.Models.Entities;

namespace QuanLyNhanLuc.Models.ViewModels;

public class ThemNhanVienVM
{
    public SelectList? Departments { get; set; }
    public SelectList? ChucVus { get; set; }
    public SelectList? NhanSuTypes { get; set; }
}
