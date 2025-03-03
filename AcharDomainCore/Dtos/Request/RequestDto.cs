using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.AspNetCore.Http;

namespace AcharDomainCore.Dtos.Request
{
    public class RequestDto
    {
        public int Id { get; set; }
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = "وارد کردن قیمت الزامی است")]
        public decimal Price { get; set; }
        [DisplayName("عکس ها")]
        public List<IFormFile>? Images { get; set; } = new List<IFormFile>();

        [DisplayName("وضعیت")]
        public StatusRequestEnum Status { get; set; }

        [DisplayName("تعیین روز")]
        [Required(ErrorMessage = "وارد کردن تاریخ پیشنهادی الزامی است")]
        public DateTime RequesteForTime { get; set; }

        [DisplayName("شناسه مشتری")]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        [DisplayName("شناسه خدمات")]
        [Required(ErrorMessage = "وارد کردن شناسه خدمات الزامی است")]
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [DisplayName("تعیین روز")]
        public DateTime? DoneAt { get; set; }

    }
}
