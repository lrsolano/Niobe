using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateNivelDTO : CommomCreateEnderecoDTO
    {
        [Required]
        public long IdNivel{ get; set; }
    }
}
