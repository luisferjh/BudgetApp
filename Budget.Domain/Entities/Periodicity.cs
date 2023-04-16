using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class Periodicity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AmountPay { get; set; }
        public int AmountPayYear { get; set; }
        public int MonthUnit { get; set; }
        public int DayUnit { get; set; }
        public bool IsFixedInterval { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public List<CashFlowFixed> CashFlowFixeds { get; set; }
    }
}
