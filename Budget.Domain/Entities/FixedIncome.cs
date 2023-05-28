using Budget.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class FixedIncome
    {
        public int Id { get; set; }
        public int IdOperation { get; set; }
        public int IdIncomeCategory { get; set; }
        public int IdUser { get; set; }
        public int IdPaymentDatePeriod { get; set; }
        public int? IdWallet { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int IdState { get; set; }

        public State State { get; set; }
        public Operation Operation { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public PaymentDatePeriod PaymentDatePeriod { get; set; }
        public User User { get; set; }             
        //public CategoryID CategoryID { get; set; }

    }
}
