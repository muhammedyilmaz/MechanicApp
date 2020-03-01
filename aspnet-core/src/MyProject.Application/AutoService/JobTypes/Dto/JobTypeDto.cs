using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.JobTypes.Dto
{
    [AutoMapFrom(typeof(JobType))]
    public class JobTypeDto : EntityDto
    {
        public string Name { get; set; }
    }
}