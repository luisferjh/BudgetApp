using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string DNIType { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int State { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<UserClaims> UserClaims { get; set; }
        public List<Wallet> Wallets { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Spent> Spents { get; set; }
        public List<CashFlowFixed> CashFlowFixeds { get; set; }
    }
}
