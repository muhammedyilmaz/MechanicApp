using Abp.Application.Services.Dto;

namespace MyProject.MultiTenancy.Dto
{
    public class PagedTenantResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}

