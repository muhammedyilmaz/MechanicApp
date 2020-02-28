using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.AutoService
{
    [Table(nameof(StockQuantityHistory))]
    public class StockQuantityHistory : FullAuditedEntity, IMustHaveTenant
    {
        public int QuantityAdjustment { get; set; }
        public int StockQuantity { get; set; }
        public string Message { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public virtual int PartId { get; set; }
        public virtual Part Part { get; set; }
        public int TenantId { get; set; }
    }
}
