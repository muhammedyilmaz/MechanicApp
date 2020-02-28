using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "inventory tracking" filter (0 - all; 1 - inventory tracking Yes; 2 - inventory tracking no;
    /// </summary>
    public enum InventoryTrackingEnum
    {
        [Display(Name = "InventoryTrackingYes")]
        InventoryTrackingYes = 1,
        [Display(Name = "InventoryTrackingNo")]
        InventoryTrackingNo = 2
    }
}
