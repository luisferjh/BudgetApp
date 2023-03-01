using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOS.Models
{
    public class ResponseServiceDTO
    {
        public bool Result { get; set; }
        public object? Response { get; set; }
        public string Message { get; set; }
    }
}
