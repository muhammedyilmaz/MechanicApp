using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarMakes.Dto
{
    [AutoMapTo(typeof(CarMake))]
    public class UpdateCarMakeDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
    }
}