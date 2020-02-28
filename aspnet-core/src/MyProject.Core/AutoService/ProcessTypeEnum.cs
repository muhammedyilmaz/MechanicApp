using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "process type" filter (0 - all; 1 - process type part; 2 - process type job type;)
    /// </summary>
    public enum ProcessTypeEnum
    {

        //parça
        [Display(Name = "AutoServiceServiceRecordDetailsProcessTypePart")]
        Part = 1,

        //işçilik
        [Display(Name = "AutoServiceServiceRecordDetailsProcessTypeJobType")]
        JobType = 2
    }
}
