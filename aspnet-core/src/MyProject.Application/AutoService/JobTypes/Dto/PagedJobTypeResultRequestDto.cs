using Abp.Application.Services.Dto;

namespace MyProject.AutoService.JobTypes.Dto
{
    public class PagedJobTypeResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
