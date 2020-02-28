using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    /// <summary>
    /// Servis kaydı müşteri şikatetlerini temsil eder
    /// </summary>
    [Table(nameof(ServiceRecordCustomerComplaint))]
    public class ServiceRecordCustomerComplaint : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// Açıklama
        /// </summary>
        [Required]
        [MinLength(MinNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Servis kayıt id
        /// </summary>
        [Required]
        [ForeignKey("ServiceRecord")]
        public virtual int ServiceRecordId { get; set; }
        public virtual ServiceRecord ServiceRecord { get; set; }
        public int TenantId { get; set; }
    }
}
