using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.SubCategoryDto
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
