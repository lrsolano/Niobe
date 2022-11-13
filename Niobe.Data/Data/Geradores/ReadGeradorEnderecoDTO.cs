using Niobe.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class ReadGeradorEnderecoDTO
    {
        public long Id { get; set; }
        public long IdArmazem { get; set; }
        public string NomeRua { get; set; }
        public string CodigoRua { get; set; }
        public TipoDado TipoRua { get; set; }
        public long QuantidadeRua { get; set; }
        public string NomeColuna { get; set; }
        public string CodigoColuna { get; set; }
        public TipoDado TipoColuna { get; set; }
        public long QuantidadeColuna { get; set; }
        public string NomeNivel { get; set; }
        public string CodigoNivel { get; set; }
        public TipoDado TipoNivel { get; set; }
        public long QuantidadeNivel { get; set; }
        public string NomeBloco { get; set; }
        public string CodigoBloco { get; set; }
        public bool BlocoAB { get; set; } = false;
        public long QuantidadeBloco { get; set; }
        public string PadraoEndereco { get; set; }
        public bool GeracaoCompletada { get; set; }
    }
}
