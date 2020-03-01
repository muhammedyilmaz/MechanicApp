using Abp.AutoMapper;

namespace MyProject.AutoService.JobTypes.Dto
{
    [AutoMapTo(typeof(JobType))]
    public class CreateJobTypeDto
    {
        public string Name { get; set; }
    }
}