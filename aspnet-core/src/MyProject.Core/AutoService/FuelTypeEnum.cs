using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{ 
    /// <summary>
    /// prepare "fuel type" filter (0 - all; 1 - fuel type gasoline; 2 - fuel type gasolineAndLpg; 3 - fuel type diesel
    /// 4 - fuel type hybrid; 5 - fuel type electric)
    /// </summary>
    public enum FuelTypeEnum
    {
        [Display(Name = "AutoServiceVehiclesFuelTypeGasoline")]
        Gasoline = 1,
        [Display(Name = "AutoServiceVehiclesFuelTypeGasolineAndLpg")]
        GasolineAndLpg = 2,
        [Display(Name = "AutoServiceVehiclesFuelTypeDiesel")]
        Diesel = 3,
        [Display(Name = "AutoServiceVehiclesFuelTypeHybrid")]
        Hybrid = 4,
        [Display(Name = "AutoServiceVehiclesFuelTypeElectric")]
        Electric = 5
    }
}
