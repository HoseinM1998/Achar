using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Enums
{
    public enum StatusBidEnum
    {
        [Display(Name = "درانتظار تایید مشتری")]
        WaitingForCustomerConfirmation = 1,
        [Display(Name = "درانتظار مراجعه متخصص")]
        WaitingForExpert,
        [Display(Name = "توسط مشتری کنسل شد")]
        CancelledByCustomer,
        [Display(Name = "ردشد")] 
        Rejected,
        [Display(Name = "با‌موفقیت انجام‌شد")]
        Success
    }
}
