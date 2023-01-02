using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateEnderecoDTO : CommomCreateContratoDTO
    {
        [StringLength(50, ErrorMessage = "Rua grande de mais")]
        public string Logradouro { get; set; }
        [StringLength(50, ErrorMessage = "Bairro grande de mais")]
        public string Bairro { get; set; }
        [StringLength(8, ErrorMessage = "CEP grande de mais")]
        public string CEP { get; set; }
        [StringLength(5, ErrorMessage = "Número grande de mais")]
        public string Numero { get; set; }
        [StringLength(50, ErrorMessage = "Caixa Postal grande de mais")]
        public string CaixaPostal { get; set; }
        [StringLength(50, ErrorMessage = "Complemento grande de mais")]
        public string Complemento { get; set; }
        [StringLength(50, ErrorMessage = "Cidade grande de mais")]
        public string Cidade { get; set; }
    }
}
