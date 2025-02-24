using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.HomeServiceDto
{
    public class HomeServiceGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal BasePrice { get; set; }
    }
}
