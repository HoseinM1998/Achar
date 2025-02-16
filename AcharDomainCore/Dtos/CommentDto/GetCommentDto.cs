using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.CommentDto
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "امتیاز")]
        public int Score { get; set; }
        [Display(Name = "نام مشتری")]
        public string CustomerName { get; set; }
        [Display(Name = "نام کارشناس")]
        public string ExpertName { get; set; }
        public DateTime CreatAt { get; set; }
    }
}
