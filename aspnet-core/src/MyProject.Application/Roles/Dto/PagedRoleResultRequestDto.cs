using Abp.Application.Services.Dto;

namespace MyProject.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}

