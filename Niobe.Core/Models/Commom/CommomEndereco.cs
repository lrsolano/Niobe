using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public abstract class CommomEndereco
    {
        public long Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public long Ordem { get; private set; }
    }
}
