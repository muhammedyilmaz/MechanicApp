using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "customer address type" filter (0 - all; 1 - customer address type home address; 2 - customer address type business address;
    /// </summary>
    public enum CustomerAddressTypeEnum
    {
        [Display(Name = "AutoServiceCustomersCustomerAddressHomeAddress")]
        HomeAddress = 1,
        [Display(Name = "AutoServiceCustomersCustomerAddressBusinessAddress")]
        BusinessAddress = 2
    }
}
