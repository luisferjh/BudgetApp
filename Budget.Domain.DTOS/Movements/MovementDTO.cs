using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.Movements
{
    public class MovementDTO
    {
        public string Id { get; set; }
        public int IdAccountingEntry { get; set; }
        public int IdOperation { get; set; }
        public int IdPreviousTransaction { get; set; }
        public string TransactionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string DNI { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
