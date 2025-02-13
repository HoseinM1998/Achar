using System.ComponentModel.DataAnnotations;

namespace AcharDomainCore.Dtos.BidDto
{
    public class BidUpdateDto
    {
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت پیشنهادی")]
        public decimal BidPrice { get; set; }
        [Display(Name = "تاریخ پیشنهادی")]
        public DateTime BidDate { get; set; }
    }
}
