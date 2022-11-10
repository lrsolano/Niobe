using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public abstract class CommomContrato
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
