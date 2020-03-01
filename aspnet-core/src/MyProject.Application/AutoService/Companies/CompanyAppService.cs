using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MyProject.Authorization;
using MyProject.AutoService.Companies.Dto;

namespace MyProject.AutoService.Companies
{
    public class CompanyAppService : AsyncCrudAppService<Company, CompanyDto, int, PagedCompanyResultRequestDto, CreateCompanyDto, UpdateCompanyDto>, ICompanyAppService
    {
        private readonly IRepository<Company, int> _repository;
        public CompanyAppService(IRepository<Company, int> repository) : base(repository)
        {
            _repository = repository;
        }

        [AbpAuthorize(PermissionNames.Company_Edit)]
        public override Task<CompanyDto> UpdateAsync(UpdateCompanyDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Company_Create)]
        public override async Task<CompanyDto> CreateAsync(CreateCompanyDto input)
        {
            return await base.CreateAsync(input);
        }

        protected override IQueryable<Company> CreateFilteredQuery(PagedCompanyResultRequestDto input)
        {
            return Repository.GetAllIncluding()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        [AbpAuthorize(PermissionNames.Company_List)]
        public override Task<PagedResultDto<CompanyDto>> GetAllAsync(PagedCompanyResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.Company_Delete)]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var company = await _repository.GetAsync(input.Id);
            await _repository.DeleteAsync(company);
        }

        [AbpAuthorize(PermissionNames.Company_Delete)]
        public async Task BulkDeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var company = await _repository.GetAsync(id);
                await _repository.DeleteAsync(company);
            }
        }
    }
}