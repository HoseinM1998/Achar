using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.BidDto
{
    public class BidAddDto
    {

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        public string Description { get; set; }
        [Display(Name = "قیمت پیشنهادی")]
        [Required(ErrorMessage = "وارد کردن قیمت پیشنهادی الزامی است")]
        public decimal BidPrice { get; set; }
        [Display(Name = "تاریخ پیشنهادی")]
        [Required(ErrorMessage = "وارد کردن تاریخ پیشنهادی الزامی است")]
        public DateTime BidDate { get; set; }

        [Display(Name = "ایدی متخصص")]
        public int ExpertId { get; set; }
        [Display(Name = "ایدی مشتری")]
        public int RequestId { get; set; }
        public StatusBidEnum Status { get; set; }

    }
}
