﻿using HomeService.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.CustomerDto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public decimal? Balance { get; set; }
        public GenderEnum? Gender { get; set; }
        public int CityId { get; set; }

    }
}
