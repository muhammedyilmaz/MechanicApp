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
using MyProject.AutoService.JobTypes.Dto;

namespace MyProject.AutoService.JobTypes
{
    public class JobTypeAppService : AsyncCrudAppService<JobType, JobTypeDto, int, PagedJobTypeResultRequestDto, CreateJobTypeDto, UpdateJobTypeDto>, IJobTypeAppService
    {
        private readonly IRepository<JobType, int> _repository;
        public JobTypeAppService(IRepository<JobType, int> repository) : base(repository)
        {
            _repository = repository;
        }

        [AbpAuthorize(PermissionNames.JobType_Edit)]
        public override Task<JobTypeDto> UpdateAsync(UpdateJobTypeDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.JobType_Create)]
        public override async Task<JobTypeDto> CreateAsync(CreateJobTypeDto input)
        {
            return await base.CreateAsync(input);
        }

        protected override IQueryable<JobType> CreateFilteredQuery(PagedJobTypeResultRequestDto input)
        {
            return Repository.GetAllIncluding()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        [AbpAuthorize(PermissionNames.JobType_List)]
        public override Task<PagedResultDto<JobTypeDto>> GetAllAsync(PagedJobTypeResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.JobType_Delete)]
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var jobType = await _repository.GetAsync(input.Id);
            await _repository.DeleteAsync(jobType);
        }

        [AbpAuthorize(PermissionNames.JobType_Delete)]
        public async Task BulkDeleteAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var jobType = await _repository.GetAsync(id);
                await _repository.DeleteAsync(jobType);
            }
        }
    }
}