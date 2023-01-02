using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Armazem : CommomEndereco
    {
        public virtual Filial Filial { get; set; }
        public virtual List<Rua> Ruas { get; set; }
        public virtual List<Contrato> Contratos { get; set; }
        [Required]
        public long IdFilial { get; set; }

    }
}
