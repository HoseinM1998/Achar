using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "آقا")]
        Male =1,
        [Display(Name = "خانوم")]
        Female
    }
}
