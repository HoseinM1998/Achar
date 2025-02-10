using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.Enums
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
        [Display(Name = "عدم مراجعه کارشناس")]
        Failed,
        [Display(Name = "کنسل‌شد")]
        Cancelled,
        [Display(Name = "ردشد")]
        Rejected,
    }
}