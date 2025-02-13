using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }
        [Display(Name = "عکس")]
        public string? Image { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<SubCategory>? SubCategories { get; set; } = new List<SubCategory>();

    }
}
