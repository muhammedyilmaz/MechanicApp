using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MyProject.AutoService.CarMakes.Dto
{
    [AutoMapFrom(typeof(CarMake))]
    public class CarMakeDto : EntityDto
    {
        public string Name { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}