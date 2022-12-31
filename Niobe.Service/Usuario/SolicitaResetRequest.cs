using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Service
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
