﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Title { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [DisplayName("قیمت")]
        public decimal Price { get; set; }
        [DisplayName("عکس ها")]
        public List<IFormFile>? Images { get; set; }

        [DisplayName("وضعیت")]
        public StatusRequestEnum Status { get; set; }

        [DisplayName("تعیین روز")]
        public DateTime RequesteForTime { get; set; }

        [DisplayName("شناسه مشتری")]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        [DisplayName("شناسه خدمات")]
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [DisplayName("تعیین روز")]
        public DateTime? DoneAt { get; set; }

    }
}
