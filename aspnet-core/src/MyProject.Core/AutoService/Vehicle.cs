using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(Vehicle))]
    public class Vehicle : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Plate"/> property.
        /// </summary>
        public const int MinPlateLength = 2;

        /// <summary>
        /// Plaka
        /// </summary>
        [Required]
        [MinLength(MinPlateLength)]
        public string Plate { get; set; }

        /// <summary>
        /// Müşteri Id
        /// </summary>
        [Required]
        [ForeignKey("Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Araba markası Id
        /// </summary>
        public int? CarMakeId { get; set; }

        /// <summary>
        /// Araba modeli Id
        /// </summary>
        public int? CarModelId { get; set; }

        /// <summary>
        /// Cinsi
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Motor numarası
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// Şasi numarası
        /// </summary>
        public string ChassisNumber { get; set; }

        /// <summary>
        /// Ruhsat No
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Model yılı
        /// </summary>
        public int? ModelYear { get; set; }

        /// <summary>
        /// Renk
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Yakıt türü (enum olacak)
        /// </summary>
        public int? FuelType { get; set; }

        /// <summary>
        /// Vites türü (enum olacak)
        /// </summary>
        public int? GearType { get; set; }

        /// <summary>
        /// Servis hatırlatması
        /// </summary>
        public string ServiceReminder { get; set; }

        public int TenantId { get; set; }
    }
}