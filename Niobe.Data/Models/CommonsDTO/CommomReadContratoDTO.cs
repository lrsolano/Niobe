using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public abstract class CommomReadContratoDTO
    { 
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
