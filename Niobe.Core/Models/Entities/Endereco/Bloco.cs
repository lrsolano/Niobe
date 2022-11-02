using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Core
{
    public sealed class Bloco : CommomEndereco
    {
        public Nivel Nivel { get; private set; }
        public string EnderecoFisico { get; private set; }
    }
}
