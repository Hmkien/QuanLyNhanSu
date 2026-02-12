using QuanLyNhanLuc.Models.Enums;
using System.ComponentModel;
using System.Reflection;

namespace QuanLyNhanLuc.Helpers;

public static class RoleTypeHelper
{
    public static string GetDescription(this RoleType roleType)
    {
        FieldInfo? field = roleType.GetType().GetField(roleType.ToString());
        if (field != null)
        {
            DescriptionAttribute? attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? roleType.ToString();
        }
        return roleType.ToString();
    }

    public static List<(RoleType Type, string Code, string Description)> GetAllRoles()
    {
        return Enum.GetValues<RoleType>()
            .Select(r => (r, r.ToString(), r.GetDescription()))
            .ToList();
    }
}
