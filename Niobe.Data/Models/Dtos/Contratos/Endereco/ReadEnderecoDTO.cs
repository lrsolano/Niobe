using Niobe.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class ReadEnderecoDTO : CommomReadContratoDTO
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string CaixaPostal { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public long IdContrato { get; set; }
        public long IdCliente { get; set; }
    }
}
