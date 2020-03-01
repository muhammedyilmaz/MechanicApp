using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.JobTypes.Dto
{
    [AutoMapTo(typeof(JobType))]
    public class UpdateJobTypeDto : EntityDto
    {
        public string Name { get; set; }
    }
}