using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Code { get; set; }
        public int IdState { get; set; }
        public bool IsNeoBank { get; set; }
        public List<Wallet> Wallets { get; set; }
        public State State { get; set; }
    }
}
