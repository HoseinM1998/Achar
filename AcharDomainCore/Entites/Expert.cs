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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }
        public string? Street { get; set; }

        [Display(Name = "موجودی")]
        public int? Balance { get; set; }
        public int? Score { get; set; } 
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public GenderEnum? Gender { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public List<HomeService>? Services { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Proposal>? Bids { get; set; } = new List<Proposal>();
        public List<Request>? AcceptedRequests { get; set; } = new List<Request>();
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
