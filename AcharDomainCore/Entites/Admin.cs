using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class Admin
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public decimal? Balance { get; set; }

    }
}
