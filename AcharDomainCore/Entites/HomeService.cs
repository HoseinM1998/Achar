using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class HomeService
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
        public string Title { get; set; }
        public string? ImageSrc { get; set; }
        public decimal BasePrice { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public List<Request>? Requests { get; set; } = new List<Request>();
        public List<Expert> Experts { get; set; } = new List<Expert>();

    }
}
