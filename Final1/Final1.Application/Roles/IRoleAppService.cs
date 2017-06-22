using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Final1.Authorization.Roles;
using Final1.Roles.Dto;

namespace Final1.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task<IQueryable<Role>> GetAllRoles();

        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
