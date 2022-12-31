using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Cliente
    {
        public long Id { get; set; }
        public string NomeAbreviado { get; set; }
        public string TipodeCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public virtual Endereco Endereco { get; set; }
        [Required]
        public long IdEndereco { get; set; }
        public virtual Contrato Contrato { get; set; }
        [Required]
        public long IdContrato { get; set; }
    }
}
