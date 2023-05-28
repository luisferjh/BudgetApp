using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.FixedIncomes
{
    public class FixedIncomeDTO
    {
        public int Id { get; set; }
        public int IdIncomeCategory { get; set; }
        public int IdUser { get; set; }
        public int IdFinancialProduct { get; set; }       
        public int IdOperation { get; set; }
        public string TransactionNumber { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
      
    }
}
