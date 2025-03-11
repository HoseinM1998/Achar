using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;

namespace AcharDomainCore.Dtos.Request
{
    public class RequestGetDto
    {
        public int Id { get; set; }
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("قیمت")]
        public decimal Price { get; set; }
        [DisplayName("عکس ها")]
        public List<Image>? Images { get; set; } = new List<Image>();
        public List<string> ImagePaths { get; set; }

        [DisplayName("وضعیت")]
        public StatusRequestEnum Status { get; set; }

        [DisplayName("تعیین روز")]
        public DateTime RequesteForTime { get; set; }
        public DateTime CreateAt { get; set; }

        [DisplayName("شناسه مشتری")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        [DisplayName("شناسه خدمات")]
        public int ServiceId { get; set; }
        public string HomeServiceName { get; set; }

        [DisplayName("شناسه کارشناس")]
        public int? ExpertId { get; set; }
        public string? ExpertName { get; set; }
        public List<Bid>? Bids { get; set; } = new List<Bid>();
        public DateTime? DoneAt { get; set; }
        public bool Canccell { get; set; }=false;



    }
}
