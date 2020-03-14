using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace MyProject.AutoService.CarMakes.Dto
{
    public class PagedCarMakeResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public List<long?> CreatorUserIds { get; set; }
        public List<long?> LastModifierUserIds { get; set; }
    }
}
