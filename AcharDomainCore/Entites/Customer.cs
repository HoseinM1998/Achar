using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HomeService.Domain.Core.Enums;

namespace AcharDomainCore.Entites
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Street { get; set; }

        [Display(Name = "موجودی")]
        public decimal?  Balance { get; set; }
        public bool IsDeleted { get; set; } = false;
        public GenderEnum? Gender { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Request>? Requests { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
