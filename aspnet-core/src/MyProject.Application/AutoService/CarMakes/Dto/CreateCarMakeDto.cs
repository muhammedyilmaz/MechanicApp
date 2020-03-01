using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarMakes.Dto
{
    [AutoMapTo(typeof(CarMake))]
    public class CreateCarMakeDto
    {
        [Required]
        public string Name { get; set; }
    }
}