using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public abstract class CommomEndereco
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage ="Código é um campo obrigatório")]
        [StringLength(10, ErrorMessage = "Telefone grande de mais")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(25, ErrorMessage = "Telefone grande de mais")]
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        [Required(ErrorMessage = "Ordem é um campo obrigatório")]
        public long Ordem { get; set; }
    }
}
