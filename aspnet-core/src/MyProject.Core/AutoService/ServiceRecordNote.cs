using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(ServiceRecordNote))]
    public class ServiceRecordNote : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Content"/> property.
        /// </summary>
        public const int MinContentLength = 2;

        /// <summary>
        /// İçerik
        /// </summary>
        [Required]
        [MinLength(MinContentLength)]
        public string Content { get; set; }

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
