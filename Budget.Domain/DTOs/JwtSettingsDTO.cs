﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOs
{
    public class JwtSettingsDTO
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
