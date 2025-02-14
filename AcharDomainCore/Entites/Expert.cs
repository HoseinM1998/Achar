using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HomeService.Domain.Core.Enums;

namespace AcharDomainCore.Entites
{
    public class Expert
    {
        public int Id { get; set; }
        public int? Score { get; set; } 
        public GenderEnum? Gender { get; set; }
        public bool IsActive { get; set; } = false;
        public List<SubCategory>? Skills { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Bid>? Bids { get; set; } = new List<Bid>();
        public List<Request>? Requests { get; set; } = new List<Request>();
        public int CityId { get; set; }
        public City City { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
