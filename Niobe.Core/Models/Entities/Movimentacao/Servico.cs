using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public sealed class Servico
    {
        public long Id { get; private set; }
        public StatusMovimentacao StatusFinal { get; private set; }
        public StatusMovimentacao StatusInicial { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public bool GeracaoVolume { get; private set; }
        public bool DevolucaoCliente { get; private set; }
        public bool DevolucaoMidia { get; private set; }
        public bool SaidaCliente { get; private set; }
        public bool SaidaMidia { get; private set; }
        public bool CancelamentoVolume { get; private set; }
        public bool ConsultaInterna { get; private set; }
        public bool ConsultaOrganizacao { get; private set; }
        public bool GED { get; private set; }
        public bool ServicoAvulso { get; private set; }
        public bool ServicoMigracao { get; private set; }
        public bool Digitalizacao { get; private set; }
        public bool ConsultaResgate { get; private set; }
        public bool InsercaoDocumento { get; private set; }
        public bool ListaSeparacao { get; private set; }
        public bool Manuseio { get; private set; }
        public bool Transposicao { get; private set; }
        public bool Ativo { get; private set; }
    }
}
