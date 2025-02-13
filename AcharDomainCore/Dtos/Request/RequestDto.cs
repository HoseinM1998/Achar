using HomeService.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.Request
{
    public class RequestDto
    {
        public int Id { get; set; }
        [DisplayName("عنوان")]
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("قیمت")]
        public decimal Price { get; set; }
        [DisplayName("عکس ها")]
        public string? ImageSrc { get; set; }
        [DisplayName("وضعیت")]
        public StatusRequestEnum Status { get; set; }

        [DisplayName("تعیین روز")]
        public DateTime RequesteForTime { get; set; }

        [DisplayName("شناسه مشتری")]
        public int CustomerId { get; set; }
        [DisplayName("شناسه خدمات")]
        public int ServiceId { get; set; }

    }
}
