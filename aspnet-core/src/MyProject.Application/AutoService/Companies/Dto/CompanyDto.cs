using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.Companies.Dto
{
    [AutoMapFrom(typeof(Company))]
    public class CompanyDto : EntityDto
    {
        public string Name { get; set; }
    }
}