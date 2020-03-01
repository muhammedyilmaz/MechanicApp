using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.Companies.Dto
{
    [AutoMapTo(typeof(Company))]
    public class UpdateCompanyDto : EntityDto
    {
        public string Name { get; set; }
    }
}