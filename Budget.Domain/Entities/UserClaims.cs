﻿

namespace Budget.Domain.Entities
{
    public class UserClaims
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public User User { get; set; }
    }
}
