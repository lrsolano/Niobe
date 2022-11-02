using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public sealed class Filial : CommomEndereco
    {
        public string CNPJ { get; private set; }
        public string Telefone { get; private set; }
    }
}
