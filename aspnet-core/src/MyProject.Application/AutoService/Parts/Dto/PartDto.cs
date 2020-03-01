using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MyProject.AutoService.Parts.Dto
{
    [AutoMapFrom(typeof(Part))]
    public class PartDto : EntityDto
    {
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public string CreatorUserFullName { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string LastModifierUserFullName { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int InventoryTracking { get; set; }
        public string InventoryTrackingText { get; set; }
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