using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.Wallet
{
    public class WalletDTO
    {
        public string Id { get; set; }
        public int IdFinancialProd { get; set; }
        public int IdUser { get; set; }
        public int IdBank { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string DNI { get; set; }      
       
    }
}
