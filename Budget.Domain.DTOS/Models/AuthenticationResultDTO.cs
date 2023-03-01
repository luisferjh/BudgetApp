using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOS.Models
{
    public class AuthenticationResultDTO
    {
        public AuthenticationResultDTO()
        {
            Errors = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public object Result { get; set; }

    }
}
