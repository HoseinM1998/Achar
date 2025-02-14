using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Entites
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }

    }
}
