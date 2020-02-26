using Abp.Application.Services;
using MyProject.MultiTenancy.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
        Task BulkDeleteAsync(List<int> ids);
    }
}

