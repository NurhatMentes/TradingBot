using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public class RedisConfiguration
    {
        public bool Enabled { get; set; }
        public IConfiguration ConnectionString { get; set; }
    }
}
