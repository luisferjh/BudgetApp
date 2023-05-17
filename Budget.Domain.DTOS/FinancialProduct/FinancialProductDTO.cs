using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.FinancialProduct
{
    public class FinancialProductDTO
    {
        public string Id { get; set; }
        public int IdAccountingEntry { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }
    }
}
