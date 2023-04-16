using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class PaymentDatePeriod
    {
        public int Id { get; set; }
        public int IdCashFlowFixed { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string PaymentDate { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public CashFlowFixed CashFlowFixed { get; set; }
    }
}
