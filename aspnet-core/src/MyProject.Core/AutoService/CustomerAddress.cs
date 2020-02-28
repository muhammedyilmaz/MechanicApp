using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(CustomerAddress))]

    public class CustomerAddress : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Adres tip (enum olacak(ev adresi, iş adresi, fatura adresi))
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Ülke id
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Şehir id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Adres
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Müşteri Id
        /// </summary>
        [Required]
        [ForeignKey("Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int TenantId { get; set; }
    }
}
