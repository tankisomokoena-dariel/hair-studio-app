using System.ComponentModel;

namespace Domain.Enums
{
    public enum UserRoles
    {
        [Description("Administrator")]
        Admin,
        [Description("Customer")]
        Customer
    }
}
