using System;
using System.Collections.Generic;

namespace QuanLyNhanLuc.Models.ViewModels;

public class DashboardVM
{
    public ThongKeHomNayVM ThongKeHomNay { get; set; } = new ThongKeHomNayVM();
    public ThongKeNhanSuVM ThongKeNhanSu { get; set; } = new ThongKeNhanSuVM();
    public ThongKeThuTucVM ThongKeThuTuc { get; set; } = new ThongKeThuTucVM();
    public ThongKeChartVM ThongKeChart { get; set; } = new ThongKeChartVM();
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
    public List<ChartDataVM> ThongKeNhanVien { get; set; } = new List<ChartDataVM>();
    public List<ChartDataVM> TyLeNhanVien { get; set; } = new List<ChartDataVM>();
    public List<ChartDataVM> ThongKeTuyenDung { get; set; } = new List<ChartDataVM>();
    public List<ChartDataVM> SoLuongNhanVienTheoThang { get; set; } = new List<ChartDataVM>();
}

public class ChartDataVM
{
    public string Label { get; set; } = string.Empty;
    public int Value { get; set; }
} 