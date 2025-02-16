using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Entities.Config
{
    public class SiteSetting
    {
        public SqlConfigurations SqlConfigurations { get; set; }

    }
    public class SqlConfigurations
    {
        public string ConnectionString { get; set; }
    }

}
