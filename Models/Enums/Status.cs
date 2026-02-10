using System.ComponentModel;

namespace QuanLyNhanLuc.Models.Enums
{
    public enum Status
    {
        [Description("Đã phê duyệt")]
        Approved,

        [Description("Đang chờ duyệt")]
        Pending,

        [Description("Đã hủy")]
        Canceled,

        [Description("Bị từ chối")]
        Rejected
    }
}
