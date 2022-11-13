using Niobe.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateGeradorEnderecoDTO
    {
        [Required]
        public long IdArmazem { get; set; }
        [Required]
        public string NomeRua { get; set; }
        public string CodigoRua { get; set; }
        [Required]
        public TipoDado TipoRua { get; set; }
        [Required]
        public long QuantidadeRua { get; set; }
        [Required]
        public string NomeColuna { get; set; }
        public string CodigoColuna { get; set; }
        [Required]
        public TipoDado TipoColuna { get; set; }
        [Required]
        public long QuantidadeColuna { get; set; }
        [Required]
        public string NomeNivel { get; set; }
        public string CodigoNivel { get; set; }
        [Required]
        public TipoDado TipoNivel { get; set; }
        [Required]
        public long QuantidadeNivel { get; set; }
        [Required]
        public string NomeBloco { get; set; }
        public string CodigoBloco { get; set; }
        public bool BlocoAB { get; set; } = false;
        [Required]
        public long QuantidadeBloco { get; set; }
        [Required]
        public string PadraoEndereco { get; set; }
    }
}
