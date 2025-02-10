using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeService.Domain.Core.Enums;

namespace AcharDomainCore.Entites
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageSrc { get; set; }
        [DisplayName("وضعیت")]
        public StatusRequestEnum Status { get; set; }
    
        [DisplayName("عکس")]
        public string? Image { get; set; }
        public bool IsDone { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DisplayName("تعیین روز")]
        public DateTime RequesteForTime { get; set; } 
        public DateTime? DoneAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? AcceptedExpertId { get; set; }
        public Expert? AcceptedExpert { get; set; }
        public int ServiceId { get; set; }
        public HomeService Service { get; set; }
        public List<Proposal>? Bids { get; set; }
    }
}
