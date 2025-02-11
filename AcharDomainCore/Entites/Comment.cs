using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "امتیاز")]
        public int Score { get; set; }
        public bool IsAccept { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

    }
}
