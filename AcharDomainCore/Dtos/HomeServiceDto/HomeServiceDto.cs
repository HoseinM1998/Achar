using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.HomeServiceDto
{
    public class HomeServiceDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }
        [Display(Name = "عکس")]
        public string? ImageSrc { get; set; }
        [Display(Name = "قیمت پایه")]
        public decimal BasePrice { get; set; }
        [Display(Name = "توضیحات کوتاه")]
        public string? ShortDescription { get; set; }
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        [Display(Name = " شناسه دسته بندی")]
        public int SubCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? CreateAt { get; set; }
        public IFormFile? ImageFile { get; set; }



    }
}
