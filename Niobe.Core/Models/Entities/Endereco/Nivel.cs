using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Nivel : CommomEndereco
    {
        public virtual Coluna Coluna { get; set; }
        public virtual List<Bloco> Blocos { get; set; }
        [Required]
        public long IdColuna { get; set; }
    }
}
