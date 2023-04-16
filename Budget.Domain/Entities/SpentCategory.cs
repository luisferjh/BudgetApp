using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class SpentCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int IdState { get; set; }

        public List<SpentDetail> SpentDetails { get; set; }
        public State State { get; set; }
        public List<CashFlowFixed> CashFlowFixeds { get; set; }

    }
}
