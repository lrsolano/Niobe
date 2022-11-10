using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Coluna : CommomEndereco
    {
        public virtual Rua Rua { get; set; }
        public virtual List<Nivel> Niveis { get; set; }
        [Required]
        public long IdRua { get; set; }
    }
}
