using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class Filial : CommomEndereco
    {
        [StringLength(16, ErrorMessage = "CNPJ grande de mais")]
        public string CNPJ { get; set; }
        [StringLength(11, ErrorMessage = "Telefone grande de mais")]
        public string Telefone { get; set; }
        public virtual List<Armazem> Armazens { get; set; }
        public virtual List<Contrato> Contratos { get; set; }
    }
}
