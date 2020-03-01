using Abp.Application.Services.Dto;

namespace MyProject.AutoService.CarModels.Dto
{
    public class PagedCarModelResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int CarMakeId { get; set; }
    }
}
