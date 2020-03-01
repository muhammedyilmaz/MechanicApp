using Abp.Application.Services.Dto;

namespace MyProject.AutoService.Companies.Dto
{
    public class PagedCompanyResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
