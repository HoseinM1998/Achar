using System.ComponentModel.DataAnnotations;

namespace AcharDomainCore.Enums
{
    public enum StatusRequestEnum
    {
        [Display(Name = "در انتظار پیشنهاد کارشناسان")]
        AwaitingSuggestionExperts =1,
        [Display(Name = "در انتظار تایید مشتری")]
        AwaitingCustomerConfirmation,
        [Display(Name = "درانتظار مراجعه کارشناس")]
        WaitingForExpert,
        [Display(Name = "با‌موفقیت انجام‌شد")]
        Success ,
        [Display(Name = " توسط مشتری کنسل‌شد")]
        CancelledByCustomer,
        [Display(Name = "توسط کارشناس کنسل شد")]
        CancelledByExpert,
    }
}