using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public sealed class Caixa
    {
        public long Id { get; private set; }
        public Bloco Bloco { get; private set; }
        public Volume Volume { get; private set; }
        public StatusMovimentacao StatusMovimentacao { get; private set; }
        public Contrato Contrato { get; private set; }
        public Departamento Departamento { get; private set; }
        public CentroCusto CentroCusto { get; private set; }
        public Pedido Pedido { get; private set; }
        public string Etiqueta { get; private set; }
        public long Serial { get; private set; }
        public long Via { get; private set; }
        public DateTime DataCancelamento { get; private set; }
        public DateTime DataExpurgo { get; private set; }
        public DateTime DataGeracao { get; private set; }
        public string Descricao { get; private set; }

    }
}
