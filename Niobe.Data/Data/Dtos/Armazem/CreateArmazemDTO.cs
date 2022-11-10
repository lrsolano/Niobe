using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateArmazemDTO : CommomEnderecoDTO
    {
        [Required]
        public long IdFilial { get; set; }
    }
}
