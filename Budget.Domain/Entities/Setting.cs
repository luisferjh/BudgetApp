using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
