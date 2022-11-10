using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Rua : CommomEndereco
    {
        public virtual Armazem Armazem { get; set; }
        public virtual List<Coluna> Colunas { get; set; }
        [Required]
        public long IdArmazem { get; set; }

    }
}
