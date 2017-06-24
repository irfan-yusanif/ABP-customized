using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Final1.Authorization.Roles;
using Final1.Roles.Dto;

namespace Final1.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : Final1AppServiceBase,IRoleAppService
    {

        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager)
        {
            

            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        public  List<Role> GetAllRoles()
        {
           return  _roleManager.Roles.ToList();
        }

        public async Task AddRoleForUser(UpdateRolePermissionsInput input)
        {
            //_roleManager.CreateStaticRoles()
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task CreateRole()
        {
            Role r = new Role();
            r.Name = "User";
            r.Permissions = new List<RolePermissionSetting>();
            r.IsDefault = true;
            //  r.IsStatic
            await _roleManager.CreateAsync(r);
        }



        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
           
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }
    }
}