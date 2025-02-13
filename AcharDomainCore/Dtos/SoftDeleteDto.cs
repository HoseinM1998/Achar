using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos
{
    public class SoftDeleteDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
