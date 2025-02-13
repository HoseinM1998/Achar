using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.CityDto
{
    public class CityDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
