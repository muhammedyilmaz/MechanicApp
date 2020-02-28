using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(ServiceRecord))]
    public class ServiceRecord : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinSurnameLength = 2;


        /// <summary>
        /// Müşteri full name
        /// </summary>
        [NotMapped]
        public string CustomerFullName => CustomerName + " " + CustomerSurname;

        /// <summary>
        /// Müşteri Adı
        /// </summary>
        [Required]
        [MinLength(MinNameLength)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Müşteri soyadı
        /// </summary>
        [Required]
        [MinLength(MinSurnameLength)]
        public string CustomerSurname { get; set; }

        /// <summary>
        /// E-Posta
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Cep telefon
        /// </summary>
        public string CustomerGsm { get; set; }

        /// <summary>
        /// Vatandaşlık numarası
        /// </summary>
        public string CustomerCitizenshipNumber { get; set; }

        /// <summary>
        /// Posta kodu
        /// </summary>
        public string CustomerPostCode { get; set; }

        /// <summary>
        /// Araba Id -> Vehicle tablosunun id'sini tutacak
        /// </summary>
        [Required]
        [ForeignKey("Vehicle")]
        public virtual int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Servise Geliş kilometresi
        /// </summary>
        public int? ArrivalKm { get; set; }

        /// <summary>
        /// Servise geldiği tarih 
        /// </summary>
        public DateTime? ArrivalDate { get; set; }

        /// <summary>
        /// Müşteri için açılacak servisteki arabanın durumunu gösterecek (tanım tablosu açılacak)
        /// </summary>
        public int? ServiceRecordStatusId { get; set; }

        /// <summary>
        /// Kendimiz için koyulacak durumlar(enum olacak. (araba tamamlandı,iptal edildi,hala serviste vb.))
        /// </summary>
        public int CompletedStatus { get; set; }

        /// <summary>
        /// Arabayı servise getiren kişi
        /// </summary>
        public string VehicleCustomerName { get; set; }
        public int TenantId { get; set; }
    }
}
