﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Enums;

namespace AcharDomainCore.Dtos.Request
{
    public class StatusRequestDto
    {
        public int Id { get; set; }
        public StatusRequestEnum Status { get; set; }

    }
}
