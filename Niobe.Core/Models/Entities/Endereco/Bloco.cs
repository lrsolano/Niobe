using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Bloco : CommomEndereco
    {
        public virtual Nivel Nivel { get; set; }
        public long IdNivel { get; set; }
        [Required]
        public string EnderecoFisico { get; set; }
        public bool Ocupado { get; set; }
    }
}
