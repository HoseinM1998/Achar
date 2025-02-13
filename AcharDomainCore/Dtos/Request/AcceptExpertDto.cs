using HomeService.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.Request
{
    public class AcceptExpertDto
    {
        public int Id { get; set; }
        public int AcceptedExpertId { get; set; }
        public StatusRequestEnum Status { get; set; }

    }
}
