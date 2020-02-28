using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(Part))]
    public class Part : FullAuditedEntity, IMustHaveTenant
    {
        /// <summary>
        /// Minimum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MinNameLength = 2;

        [Required]
        [MinLength(MinNameLength)]
        public string Name { get; set; }
        
        /// <summary>
        /// Ürün kodu / Parça kodu
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Barkod numarası
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Stok takibi yapılsın(1) yapılmasın(2)
        /// </summary>
        public int InventoryTracking { get; set; }

        /// <summary>
        /// Stok miktarı
        /// </summary>
        public int? StockQuantity { get; set; }

        /// <summary>
        /// Kritik stok mu
        /// </summary>
        public bool CriticalStock { get; set; }

        /// <summary>
        /// Kritik stok seviyesi
        /// </summary>
        public int? CriticalStockLevel { get; set; }

        /// <summary>
        /// Vergiler hariç alış fiyatı
        /// </summary>
        public decimal PurchaseAmountExcludingTaxes { get; set; }

        /// <summary>
        /// Vergiler hariç satış fiyatı
        /// </summary>
        public decimal SalesAmountExcludingTaxes { get; set; }

        /// <summary>
        /// KDV
        /// </summary>
        public int Vat { get; set; }

        /// <summary>
        /// Vergiler dahil alış fiyatı
        /// </summary>
        public decimal PurchaseAmountIncludingTaxes { get; set; }

        /// <summary>
        /// Vergiler dahil satış fiyatı
        /// </summary>
        public decimal SalesAmountIncludingTaxes { get; set; }
        public int TenantId { get; set; }
    }
}