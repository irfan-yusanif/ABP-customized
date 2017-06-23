using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Final1.Authorization;
using Final1.Roles;
using Final1.Users.Dto;
using Microsoft.AspNet.Identity;

namespace Final1.Users
{
    /* THIS IS JUST A SAMPLE. */
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : Final1AppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleAppService _roleAppService;
        
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(RoleAppService roleAppService, UserManager userManager, IRepository<User, long> userRepository, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _roleAppService = roleAppService;

            _userRepository = userRepository;
            _permissionManager = permissionManager;
        }

        public async Task<UserListDto> GetUserProfileAsync(long input)
        {
            var user = await _userManager.GetUserByIdAsync(input);
            return user.MapTo<UserListDto>();
        }


        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await UserManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<ListResultDto<UserListDto>> GetUsers()
        {
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
                );
        }

        public async Task CreateUser(CreateUserInput input)
        {
            //await _roleAppService.CreateRole(); I created from db

            var user = input.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true; //todo email conformaiton
            
            CheckErrors(await UserManager.CreateAsync(user));

           // await _roleAppService.AddRoleForUser(input.Role);
            // await _roleAppService.UpdateRolePermissions(input.Role);
        }
    }
}