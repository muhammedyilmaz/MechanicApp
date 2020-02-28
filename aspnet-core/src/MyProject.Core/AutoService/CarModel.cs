using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(CarModel))]
    public class CarModel : FullAuditedEntity, IMustHaveTenant
    {/// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        [Required]
        [MinLength(MinNameLength)]
        public string Name { get; set; }


        [Required]
        [ForeignKey("CarMake")]
        public virtual int CarMakeId { get; set; }
        public virtual CarMake CarMake { get; set; }

        public int TenantId { get; set; }
    }
}
