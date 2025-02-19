using Microsoft.AspNetCore.Http;
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
        public string Title { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "لطفاً دسته‌بندی را انتخاب کنید.")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateAt { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
