using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;

namespace AcharDomainCore.Dtos.CommentDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "امتیاز")]
        public int Score { get; set; }
        [Display(Name = "شناسه مشتری")]
        public int CustomerId { get; set; }
        [Display(Name = "شناسه کارشناس")]
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

    }
}
