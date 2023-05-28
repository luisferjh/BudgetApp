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
        public int IdPeriodicity { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string PaymentDate { get; set; }
        public string UnitDate { get; set; }
        public int Year { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public FixedIncome FixedIncome { get; set; }
        public Periodicity Periodicity { get; set; }
    }
}
