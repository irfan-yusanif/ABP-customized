using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Final1.Users.Dto;

namespace Final1.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserListDto> GetUserProfileAsync(long input);



        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);
    }
}