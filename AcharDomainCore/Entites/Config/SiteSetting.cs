using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Entities.Config
{
    public class SiteSetting
    {
        public Connectionstring ConnectionString { get; set; }

    }
    public class Connectionstring
    {
        public string SqlConnection { get; set; }
    }
}
