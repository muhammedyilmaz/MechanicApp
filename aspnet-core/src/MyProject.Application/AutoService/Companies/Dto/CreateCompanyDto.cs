using Abp.AutoMapper;

namespace MyProject.AutoService.Companies.Dto
{
    [AutoMapTo(typeof(Company))]
    public class CreateCompanyDto
    {
        public string Name { get; set; }
    }
}