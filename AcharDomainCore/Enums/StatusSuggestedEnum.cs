using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Enums
{
    public enum StatusSuggestedEnum
    {
        [Display(Name = "درانتظار تایید مشتری")]
        WaitingForCustomerConfirmation = 1,
        [Display(Name = "توسط مشتری کنسل شد")]
        CancelledByCustomer,
        [Display(Name = "درانتظار مراجعه متخصص")]
        WaitingForExpert,
        [Display(Name = "با‌موفقیت انجام‌شد")]
        Success,
        [Display(Name = "با‌موفقیت انجام‌نشد")]
        Failed ,
        [Display(Name = "کنسل‌شد")]
        Cancelled ,
        [Display(Name = "ردشد")] 
        Rejected
    }
}
