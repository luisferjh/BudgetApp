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
        public string Key { get; set; }
        public string Method { get; set; }
        public string Data { get; set; }
        public string MessageError { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string Exception { get; set; }
        public Layers Layer { get; set; }
        public DateTime DateLog { get; set; }
    }

    public enum Layers 
    {
        Domain,
        Application,
        Infrastructure,
        Presentation,
        Global
    }
}
