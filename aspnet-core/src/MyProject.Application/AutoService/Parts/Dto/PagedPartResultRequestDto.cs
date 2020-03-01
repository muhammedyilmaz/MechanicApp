using Abp.Application.Services.Dto;

namespace MyProject.AutoService.Parts.Dto
{
    public class PagedPartResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
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
