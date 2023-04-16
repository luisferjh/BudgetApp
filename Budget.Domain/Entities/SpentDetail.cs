using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class SpentDetail
    {
        public int Id { get; set; }
        public int IdSpentCategory { get; set; }
        public string Description { get; set; }
        public int IdState { get; set; }

        public SpentCategory SpentCategory { get; set; }
        public List<Spent> Spents { get; set; }
        public State State { get; set; }
        public List<CashFlowFixed> CashFlowFixeds { get; set; }
    }
}
