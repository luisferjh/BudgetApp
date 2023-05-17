using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.Incomes
{
    public class CreateIncomeCategoryDTO
    {        
        public string Code { get; set; }
        public string Description { get; set; }
        public int IdState { get; set; }
    }
}
