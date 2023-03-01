using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class LogError
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string Data { get; set; }
        public string Trace { get; set; }
        public DateTime DateLog { get; set; }
    }
}
