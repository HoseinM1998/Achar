using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AcharDomainCore.Entites
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Admin? Admin { get; set; }
        public Customer? Customer { get; set; }
        public Expert? Expert { get; set; }
        public string? Street { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public decimal? Balance { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;

    }
}
