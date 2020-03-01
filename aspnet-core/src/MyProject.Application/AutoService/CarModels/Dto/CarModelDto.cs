using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarModels.Dto
{
    [AutoMapFrom(typeof(CarModel))]
    public class CarModelDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        public int CarMakeId { get; set; }
    }
}