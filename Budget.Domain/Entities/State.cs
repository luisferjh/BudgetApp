using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class State
    {
        public int IdState { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<FinancialProduct> FinancialProducts { get; set; }
        public List<Bank> Banks { get; set; }
        public List<SpentDetail> SpentDetails { get; set; }
        public List<IncomeCategory> IncomeCategories { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Spent> Spents { get; set; }
        //public List<Periodicity> Periodicities { get; set; }
    }
}
