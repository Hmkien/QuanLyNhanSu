using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums;

public enum RoleType
{
    [Description("Qu?n tr? h? th?ng")]
    Admin = 1,

    [Description("Nhân viên phòng nhân s? (HR)")]
    HR = 2,

    [Description("Nhân viên k? toán")]
    KeToan = 3,

    [Description("Ban giám ??c")]
    BGD = 4,

    [Description("Nhân viên")]
    NhanVien = 5
}
