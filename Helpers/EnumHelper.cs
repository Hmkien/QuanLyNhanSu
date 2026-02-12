using QuanLyNhanLuc.Models.Enums;
using System.ComponentModel;
using System.Reflection;

namespace QuanLyNhanLuc.Helpers;

public static class EnumHelper
{
    public static string GetDescription<T>(this T enumValue) where T : Enum
    {
        FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
        if (field == null)
        {
            return enumValue.ToString();
        }

        DescriptionAttribute? attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? enumValue.ToString();
    }

    public static string GetEnumDescription(Enum enumValue)
    {
        FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
        if (field == null)
        {
            return enumValue.ToString();
        }

        DescriptionAttribute? attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? enumValue.ToString();
    }

    public static IEnumerable<(T Value, string Description)> GetEnumValuesWithDescription<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(e => (e, e.GetDescription()));
    }

    // Specific helpers for common enums
    public static string ToText(this TrangThaiHopDong trangThai)
    {
        return trangThai switch
        {
            TrangThaiHopDong.HieuLuc => "Hiệu lực",
            TrangThaiHopDong.HetHan => "Hết hạn",
            TrangThaiHopDong.ChamDut => "Chấm dứt",
            _ => trangThai.ToString()
        };
    }

    public static string ToText(this LoaiHopDong loai)
    {
        return loai switch
        {
            LoaiHopDong.ThuViec => "Thử việc",
            LoaiHopDong.CoThoiHan => "Có thời hạn",
            LoaiHopDong.KhongThoiHan => "Không thời hạn",
            _ => loai.ToString()
        };
    }

    public static string ToText(this TrangThaiBangLuong trangThai)
    {
        return trangThai switch
        {
            TrangThaiBangLuong.ChuaDuyet => "Chưa duyệt",
            TrangThaiBangLuong.DaDuyet => "Đã duyệt",
            TrangThaiBangLuong.DaThanhToan => "Đã thanh toán",
            _ => trangThai.ToString()
        };
    }

    public static string ToText(this TrangThaiThuTuc trangThai)
    {
        return trangThai switch
        {
            TrangThaiThuTuc.NopDon => "Nộp đơn",
            TrangThaiThuTuc.TruongPhongDuyet => "Trưởng phòng duyệt",
            TrangThaiThuTuc.KeToanDuyet => "Kế toán duyệt",
            TrangThaiThuTuc.GiamDocDuyet => "Giám đốc duyệt",
            TrangThaiThuTuc.HoanThanh => "Hoàn thành",
            TrangThaiThuTuc.TuChoi => "Từ chối",
            _ => trangThai.ToString()
        };
    }

    public static string ToText(this LoaiThuTuc loai)
    {
        return loai switch
        {
            LoaiThuTuc.NghiPhep => "Nghỉ phép",
            LoaiThuTuc.LamOnsite => "Làm onsite",
            LoaiThuTuc.HoiCo => "Hồi cố",
            LoaiThuTuc.Khac => "Khác",
            _ => loai.ToString()
        };
    }

    public static string ToText(this TrangThaiKhenThuongKyLuat trangThai)
    {
        return trangThai switch
        {
            TrangThaiKhenThuongKyLuat.ChoDuyet => "Chờ duyệt",
            TrangThaiKhenThuongKyLuat.DaDuyet => "Đã duyệt",
            TrangThaiKhenThuongKyLuat.TuChoi => "Từ chối",
            _ => trangThai.ToString()
        };
    }

    public static string ToText(this LoaiKhenThuongKyLuat loai)
    {
        return loai switch
        {
            LoaiKhenThuongKyLuat.KhenThuong => "Khen thưởng",
            LoaiKhenThuongKyLuat.KyLuat => "Kỷ luật",
            _ => loai.ToString()
        };
    }
}
