using Abp.Authorization;
using Final1.Authorization.Roles;
using Final1.MultiTenancy;
using Final1.Users;

namespace Final1.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
