using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.Operation
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }        
    }
}
