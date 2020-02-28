using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(Customer))]
    public class Customer : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="CustomerCode"/> property.
        /// </summary>
        public const int MinCustomerCodeLength = 4;

        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// Müşteri Kodu(Cari Kodu)
        /// </summary>
        [Required]
        [MinLength(MinCustomerCodeLength)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Müşteri Adı
        /// </summary>
        [Required]
        [MinLength(MinNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// E-Posta
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefon
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Cep telefon
        /// </summary>
        public string Gsm { get; set; }

        /// <summary>
        /// Vatandaşlık / Vergi No
        /// </summary>
        public string CitizenshipAndTaxNumber { get; set; }

        /// <summary>
        /// Vergi dairesi(kurumsal müşteriyse kayıt girilebilecek)
        /// </summary>
        public string TaxAdministration { get; set; }

        /// <summary>
        /// Posta kodu
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Anlaşmalı firmanın arabası ise company id tutabilecek 
        /// </summary>
        public int? CompanyId { get; set; }

        public int TenantId { get; set; }
    }
}