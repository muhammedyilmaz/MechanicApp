using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarModels.Dto
{
    [AutoMapTo(typeof(CarModel))]
    public class CreateCarModelDto
    {
        [Required]
        public string Name { get; set; }
        public int CarMakeId { get; set; }
    }
}