﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;

namespace AcharDomainCore.Dtos.Request
{
    public class RequestUpDto
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
        [DisplayName("تغییر روز")]
        public DateTime RequesteForTime { get; set; }

    }
}
