using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
