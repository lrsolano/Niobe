using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public abstract class CommomCreateContratoDTO
    {
        [Required(ErrorMessage = "Código é um campo obrigatório")]
        [StringLength(10, ErrorMessage = "Código grande de mais")]
        public string Codigo { get; set; }
        [StringLength(50, ErrorMessage = "Nome grande de mais")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
