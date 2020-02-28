using System.ComponentModel.DataAnnotations;

namespace MyProject.AutoService
{
    /// <summary>
    /// prepare "completed status" filter (0 - all; 1 - completed status completed; 2 - completed status canceled; 3 - completed status continues;
    /// </summary>
    public enum CompletedStatusEnum
    {/// <summary>
        /// Tamamlandı
        /// </summary>
        [Display(Name = "AutoServiceServiceRecordsCompletedStatusCompleted")]
        Completed = 1,

        /// <summary>
        /// Devam Ediyor
        /// </summary>
        [Display(Name = "AutoServiceServiceRecordsCompletedStatusContinues")]
        Continues = 2
    }
}
