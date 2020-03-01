using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.Parts.Dto
{
    [AutoMapTo(typeof(Part))]
    public class UpdatePartDto : EntityDto
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int InventoryTracking { get; set; }
        public int? StockQuantity { get; set; }
        public bool CriticalStock { get; set; }
        public int? CriticalStockLevel { get; set; }
        public decimal PurchaseAmountExcludingTaxes { get; set; }
        public decimal SalesAmountExcludingTaxes { get; set; }
        public int Vat { get; set; }
        public decimal PurchaseAmountIncludingTaxes { get; set; }
        public decimal SalesAmountIncludingTaxes { get; set; }
    }
}