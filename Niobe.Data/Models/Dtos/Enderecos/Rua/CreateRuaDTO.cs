using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateRuaDTO : CommomCreateEnderecoDTO
    {
        [Required]
        public long IdArmazem { get; set; }
    }
}
