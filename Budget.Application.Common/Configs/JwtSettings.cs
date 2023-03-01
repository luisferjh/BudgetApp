using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Common.Configs
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
        
    }
}
