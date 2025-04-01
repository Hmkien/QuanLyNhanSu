using System.ComponentModel;

public enum NhanSuType
{
    [Description("Nhân viên")]
    NhanVien = 1,
    [Description("Thực tập sinh")]
    ThucTapSinh = 2,
    [Description("Nhân viên chính thức")]
    NhanVienChinhThuc = 3,
    [Description("Nhân viên thời vụ")]
    NhanVienThoiVu = 4
}
