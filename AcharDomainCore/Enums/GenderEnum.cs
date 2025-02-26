using System.ComponentModel.DataAnnotations;

namespace AcharDomainCore.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "آقا")]
        Male =1,
        [Display(Name = "خانوم")]
        Female
    }
}
