using System;
using System.ComponentModel.DataAnnotations;

namespace Niobe.Core
{
    public class Contrato
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public virtual Filial Filial { get; set; }
        [Required]
        public long IdFilial { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public long IdCliente { get; set; }
        public DateTime DatadoCadastro { get; set; }
        public DateTime DatadoContrato { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DatadaProposta { get; set; }
        public bool Ativo { get; set; }
        public virtual Armazem Armazem { get; set; }
        [Required]
        public long IdArmazem { get; set; }
        public int DiaFaturamento { get; set; }
        public decimal AliquotadoISS { get; set; }
        public string Codigo { get; set; }
        [Required]
        public long Serial { get; set; }
        public virtual Endereco Endereco { get; set; }

    }
}