using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Enums;

namespace AcharDomainCore.Entites
{
    public class Proposal
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت پیشنهادی")]
        public decimal SuggestedPrice { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsAccepted { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        [Display(Name = "تاریخ پیشنهادی")]
        public DateTime SuggestedDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public StatusSuggestedEnum Status { get; set; }

        [Display(Name = "ایدی متخصص")]
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }

    }
}
