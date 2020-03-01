using Abp.Application.Services.Dto;

namespace MyProject.AutoService.CarMakes.Dto
{
    public class PagedCarMakeResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
