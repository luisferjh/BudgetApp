using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class TransactionFixed
    {
        public int Id { get; set; }
        public int IdCashFlowFixed { get; set; }
        public int IdOperation { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public CashFlowFixed CashFlowFixed { get; set; }
        public Income Income { get; set; }
        public Spent Spent { get; set; }
    }
}
