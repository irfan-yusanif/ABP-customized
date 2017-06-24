using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Final1.Authorization;
using Final1.Authorization.Roles;
using Final1.EntityFramework;
using Final1.Users;
using Microsoft.AspNet.Identity;

namespace Final1.Migrations.SeedData
{
    public class HostRoleAndUserCreator
    {
        private readonly Final1DbContext _context;

        public HostRoleAndUserCreator(Final1DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
            CreateRoles();
        }

        private void CreateRoles()
        {
            Role adminGirlRole = _context.Roles.FirstOrDefault(x => x.Name == StaticRoleNames.Host.AdminGirl);
            if (adminGirlRole == null)
            {
                adminGirlRole = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.AdminGirl, DisplayName = StaticRoleNames.Host.AdminGirl, IsStatic = true });

                //var permissions = PermissionFinder
                //    .GetAllPermissions(new Final1AuthorizationProvider())
                //    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                //    .ToList();

                //foreach (var permission in permissions)
                //{
                //    _context.Permissions.Add(
                //        new RolePermissionSetting
                //        {
                //            Name = permission.Name,
                //            IsGranted = true,
                //            RoleId = adminGirlRole.Id
                //        });
                //}

                _context.SaveChanges();
            }

            Role appraiserRole = _context.Roles.FirstOrDefault(x => x.Name == StaticRoleNames.Host.Appraiser);
            if (appraiserRole == null)
            {
                appraiserRole = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Appraiser, DisplayName = StaticRoleNames.Host.Appraiser, IsStatic = true });

                //var permissions = PermissionFinder
                //    .GetAllPermissions(new Final1AuthorizationProvider())
                //    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                //    .ToList();

                //foreach (var permission in permissions)
                //{
                //    _context.Permissions.Add(
                //        new RolePermissionSetting
                //        {
                //            Name = permission.Name,
                //            IsGranted = true,
                //            RoleId = adminGirlRole.Id
                //        });
                //}

                _context.SaveChanges();
            }

            //Grant all tenant permissions



            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();



                _context.SaveChanges();
            }
        }

        private void CreateHostRoleAndUsers()
        {
            //Admin role for host

            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new Final1AuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin user for tenancy host

            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(
                    new User
                    {
                        UserName = User.AdminUserName,
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                _context.SaveChanges();
            }
        }
    }
}