using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateFilialDTO : CommomEnderecoDTO
    {
        [StringLength(16, ErrorMessage = "CNPJ grande de mais")]
        public string CNPJ { get; set; }
        [StringLength(11, ErrorMessage = "Telefone grande de mais")]
        public string Telefone { get; set; }
    }
}
