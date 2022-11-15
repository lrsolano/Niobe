using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public abstract class CommomCreateEnderecoDTO
    {
        [Required(ErrorMessage = "Código é um campo obrigatório")]
        [StringLength(10, ErrorMessage = "Telefone grande de mais")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(25, ErrorMessage = "Telefone grande de mais")]
        public string Nome { get; set; }
    }
}
