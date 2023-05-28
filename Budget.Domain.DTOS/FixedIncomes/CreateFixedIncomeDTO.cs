using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.FixedIncomes
{
    public class CreateFixedIncomeDTO
    {
        public int IdOperation { get; set; }
        public int IdIncomeCategory { get; set; }
        public int IdUser { get; set; }
        public int IdPaymentDatePeriod { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }        
        public int IdState { get; set; }
    }
}
