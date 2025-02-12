using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class RequestRepository
    {
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
