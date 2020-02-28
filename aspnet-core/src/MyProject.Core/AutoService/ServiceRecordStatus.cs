using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(ServiceRecordStatus))]
    public class ServiceRecordStatus : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        [Required]
        [MinLength(MinNameLength)]
        public string Name { get; set; }

        public int TenantId { get; set; }
    }
}