using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "fuel type" filter (0 - all; 1 - fuel type home address; 2 - fuel type business address;
    /// </summary>
    public enum AddressTypeEnum
    {
        [Display(Name = "HomeAddress")]
        Gasoline = 1,
        [Display(Name = "BusinessAddress")]
        GasolineAndLpg = 2
    }
}
