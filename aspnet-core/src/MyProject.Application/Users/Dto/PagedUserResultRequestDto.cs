using Abp.Application.Services.Dto;
using System;

namespace MyProject.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedAndSortedResultRequestDto 
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
