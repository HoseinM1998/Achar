using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Enums;

namespace AcharDomainCore.Entites
{
    public class Bid
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت پیشنهادی")]
        public decimal BidPrice { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "تاریخ پیشنهادی")]
        public DateTime BidDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public StatusBidEnum Status { get; set; }

        [Display(Name = "ایدی متخصص")]
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }

    }
}
