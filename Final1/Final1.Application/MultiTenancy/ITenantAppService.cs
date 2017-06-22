using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Final1.MultiTenancy.Dto;

namespace Final1.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
