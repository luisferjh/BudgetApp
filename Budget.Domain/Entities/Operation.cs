using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Movement> Movements { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Spent> Spents { get; set; }      
    }
}
