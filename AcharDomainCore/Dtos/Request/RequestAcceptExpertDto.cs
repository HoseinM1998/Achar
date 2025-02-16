using AcharDomainCore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.Request
{
    public class RequestAcceptExpertDto
    {
        public int Id { get; set; }
        public List<Bid>? Bids { get; set; } = new List<Bid>();
    }
}
