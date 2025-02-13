using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.CommentDto
{
    public class CommentAcceptDto
    {
        public int Id { get; set; }
        public bool IsAccept { get; set; } = false;

    }
}
