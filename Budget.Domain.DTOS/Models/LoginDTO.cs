using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Domain.DTOS.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage="Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [StringLength(30, ErrorMessage = "Password must not have more than 30 characters")]
        public string Password { get; set; }
    }
}
