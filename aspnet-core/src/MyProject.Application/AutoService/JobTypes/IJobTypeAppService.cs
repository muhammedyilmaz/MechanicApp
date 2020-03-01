using Abp.Application.Services;
using MyProject.AutoService.JobTypes.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.AutoService.JobTypes
{
    public interface IJobTypeAppService : IAsyncCrudAppService<JobTypeDto, int, PagedJobTypeResultRequestDto, CreateJobTypeDto, UpdateJobTypeDto>
    {
        Task BulkDeleteAsync(List<int> ids);
    }
}