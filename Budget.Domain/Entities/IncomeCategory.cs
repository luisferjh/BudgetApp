using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int IdState { get; set; }

        public List<Income> Incomes { get; set; }
        public State State { get; set; }
        public List<FixedIncome> FixedIncomes { get; set; }
    }
}
