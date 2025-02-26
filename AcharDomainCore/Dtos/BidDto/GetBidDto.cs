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
    public class GetBidDto
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت پیشنهادی")]
        public decimal BidPrice { get; set; }

        [Display(Name = "تاریخ پیشنهادی")]
        public DateTime BidDate { get; set; }
        public StatusBidEnum Status { get; set; }
       
        [Display(Name = " نام متخصص")]
        public string ExpertName { get; set; }

        [Display(Name = " نام مشتری")]
        public string? RequestName { get; set; }
        public string? CustomerName { get; set; }
        public Entites.Request? Request { get; set; }
        public int? ExpertId { get; set; }
        public int? RequestId { get; set; }

    }
}
