using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(ServiceRecordDetail))]
    public class ServiceRecordDetail : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// Servis kayıt id
        /// </summary>
        [Required]
        [ForeignKey("ServiceRecord")]
        public virtual int ServiceRecordId { get; set; }
        public virtual ServiceRecord ServiceRecord { get; set; }

        /// <summary>
        /// Parça adı yada işcilik id
        /// </summary>
        [Required]
        public int PartAndJobTypeId { get; set; }

        /// <summary>
        /// Parça adı yada işcilik adı 
        /// </summary>
        [Required]
        [MinLength(MinNameLength)]
        public string PartAndJobTypeName { get; set; }

        /// <summary>
        /// İşlem tipi(enum olacak(işçilik yada parça))
        /// </summary>
        [Required]
        public int ProcessType { get; set; }

        /// <summary>
        /// Tutar
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Toplam tutar
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// KDV
        /// </summary>
        public int Vat { get; set; }

        /// <summary>
        /// Adet
        /// </summary>
        [Required]
        public int Quantity { get; set; }
        public int TenantId { get; set; }
    }
}
