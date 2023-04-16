using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class FinancialProduct
    {
        public int Id { get; set; }
        public int IdAccountingEntry { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }

        public AccountingEntry AccountingEntry { get; set; }
        public List<Wallet> FinancialProductUsers { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Spent> Spents { get; set; }
        public State State { get; set; }
    }
}
