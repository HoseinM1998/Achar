using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class HomeServiceRepository
    {
        private readonly AppDbContext _context;
        public HomeServiceRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
