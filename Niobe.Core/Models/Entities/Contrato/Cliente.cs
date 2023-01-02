using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Cliente
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string NomeAbreviado { get; set; }
        public string TipodeCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual List<Contrato> Contratos { get; set; }

    }
}
