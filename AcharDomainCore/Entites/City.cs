using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Expert> Experts { get; set; } = new List<Expert>();
    }
}
