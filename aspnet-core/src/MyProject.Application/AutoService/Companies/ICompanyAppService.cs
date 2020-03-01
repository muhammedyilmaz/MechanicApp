using Abp.Application.Services;
using MyProject.AutoService.Companies.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.AutoService.Companies
{
  
    public interface ICompanyAppService : IAsyncCrudAppService<CompanyDto, int, PagedCompanyResultRequestDto, CreateCompanyDto, UpdateCompanyDto>
    {
        Task BulkDeleteAsync(List<int> ids);
    }
}
