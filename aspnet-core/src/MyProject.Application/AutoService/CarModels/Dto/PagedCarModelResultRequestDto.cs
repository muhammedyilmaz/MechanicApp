using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace MyProject.AutoService.CarModels.Dto
{
    public class PagedCarModelResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public int CarMakeId { get; set; }
        public List<long?> CreatorUserIds { get; set; }
        public List<long?> LastModifierUserIds { get; set; }
    }
}
