using Budget.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class CashFlowFixed
    {
        public int Id { get; set; }
        public int IdOperation { get; set; }
        public int IdCategory { get; set; }
        public int IdUser { get; set; }
        public int Idperiodicity { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public Operation Operation { get; set; }
        public SpentDetail SpentDetail { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public Periodicity Periodicity { get; set; }
        public User User { get; set; }
        public List<TransactionFixed> TransactionFixeds { get; set; }
        public List<PaymentDatePeriod> PaymentDatePeriods { get; set; }
        //public CategoryID CategoryID { get; set; }

    }
}
