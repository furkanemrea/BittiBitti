using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Persistence.Configuration
{
    public abstract class DatabaseConfig
    {
        public string ConnectionString { get; set; }
    }
}
