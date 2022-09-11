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
        public string IdType { get; set; }
        public string document { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int State { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
