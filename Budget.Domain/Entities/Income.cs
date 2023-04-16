using Budget.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Budget.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public int IdIncomeCategory { get; set; }
        public int IdUser { get; set; }
        public int IdFinancialProduct { get; set; }
        public int IdState { get; set; }
        public int IdOperation { get; set; }
        public string TransactionNumber { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public IncomeCategory IncomeCategory { get; set; }
        public User User { get; set; }
        public FinancialProduct FinancialProduct { get; set; }
        public State State { get; set; }
        public Operation Operation { get; set; }
        public TransactionFixed TransactionFixed { get; set; }

    }
}
