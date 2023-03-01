using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.user.Requests
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
