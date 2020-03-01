using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarModels.Dto
{
    [AutoMapTo(typeof(CarModel))]
    public class UpdateCarModelDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        public int CarMakeId { get; set; }
    }
}