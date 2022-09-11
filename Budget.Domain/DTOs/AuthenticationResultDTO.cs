using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOs
{
    public class AuthenticationResultDTO
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public object Result { get; set; }
    }
}
