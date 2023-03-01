using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOS.Models
{
    public class JwtSettingsDTO
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
