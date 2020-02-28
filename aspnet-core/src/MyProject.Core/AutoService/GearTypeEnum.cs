using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "gear type" filter (0 - all; 1 - gear type automatic; 2 - gear type manual; 3 - gear type semi automatic)
    /// </summary>
    public enum GearTypeEnum
    {
        [Display(Name = "AutoServiceVehiclesGearTypeManual")]
        Manual = 1,
        [Display(Name = "AutoServiceVehiclesGearTypeSemiAutomatic")]
        SemiAutomatic = 2,
        [Display(Name = "AutoServiceVehiclesGearTypeAutomatic")]
        Automatic = 3
    }
}
