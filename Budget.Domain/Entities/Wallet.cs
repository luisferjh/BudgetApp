using System;
using System.Collections.Generic;

namespace Budget.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public int IdFinancialProd { get; set; }
        public int IdUser { get; set; }
        public int IdBank { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string  DNI { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public FinancialProduct FinancialProduct { get; set; }
        public User User { get; set; }
        public Bank Bank { get; set; }
    }
}
