using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateColunaDTO : CommomCreateEnderecoDTO
    {
        [Required]
        public long IdRua{ get; set; }
    }
}
