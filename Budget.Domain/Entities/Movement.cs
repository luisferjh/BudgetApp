using System;

namespace Budget.Domain.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public int IdAccountingEntry { get; set; }
        public int IdOperation { get; set; }
        public int IdPreviousTransaction { get; set; }
        public string TransactionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string DNI { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public Operation Operation { get; set; }
        public AccountingEntry AccountingEntry { get; set; }
        public Movement MovementPrevious { get; set; }        
    }
}
