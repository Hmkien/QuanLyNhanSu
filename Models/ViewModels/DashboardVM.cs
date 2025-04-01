using System;
using System.Collections.Generic;

namespace QuanLyNhanLuc.Models.ViewModels;

public class DashboardVM
{
    public ThongKeHomNayVM ThongKeHomNay { get; set; }
    public ThongKeNhanSuVM ThongKeNhanSu { get; set; }
    public ThongKeThuTucVM ThongKeThuTuc { get; set; }
    public ThongKeChartVM ThongKeChart { get; set; }
}

public class ThongKeHomNayVM
{
    public int SoNhanVienNghiPhep { get; set; }
    public int SoNhanVienCongTac { get; set; }
    public int SoNhanVienSinhNhat { get; set; }
}

public class ThongKeNhanSuVM
{
    public int TongSoNhanSu { get; set; }
    public int SoNam { get; set; }
    public int SoNu { get; set; }
}

public class ThongKeThuTucVM
{
    public int TongSoThuTuc { get; set; }
    public int SoChoDuyet { get; set; }
    public int SoDaDuyet { get; set; }
    public int SoTuChoiDuyet { get; set; }
}

public class ThongKeChartVM
{
    public List<ChartDataVM> ThongKeNhanVien { get; set; }
    public List<ChartDataVM> TyLeNhanVien { get; set; }
    public List<ChartDataVM> ThongKeTuyenDung { get; set; }
    public List<ChartDataVM> SoLuongNhanVienTheoThang { get; set; }
}

public class ChartDataVM
{
    public string Label { get; set; }
    public int Value { get; set; }
} 