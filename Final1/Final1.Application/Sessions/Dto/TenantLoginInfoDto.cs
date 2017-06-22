using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Final1.MultiTenancy;

namespace Final1.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}