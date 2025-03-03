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
        [Required(ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        public string Description { get; set; }
        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "ثبت  امتیاز الزامی است")]
        public int Score { get; set; }
        [Display(Name = "شناسه مشتری")]
        public int CustomerId { get; set; }
        [Display(Name = "شناسه کارشناس")]
        public int ExpertId { get; set; }
        public Expert? Expert { get; set; }

    }
}
