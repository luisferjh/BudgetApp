﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.DTOS.Spents
{
    public class CreateSpentDTO
    {
        public int IdSpentDetail { get; set; }
        public int IdUser { get; set; }
        public int IdFinancialProduct { get; set; }
        public int IdState { get; set; }
        public int IdOperation { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }        
    }
}
