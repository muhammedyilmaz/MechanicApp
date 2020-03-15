using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService.CarModels.Dto
{
    [AutoMapFrom(typeof(CarModel))]
    public class CarModelDto : EntityDto
    {
        public string Name { get; set; }
        public int CarMakeId { get; set; }
        public string CreatorUserFullName { get; set; }
        public string LastModifierUserFullName { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}