using System;
using System.Collections.Generic;
using System.Text;
using Niobe.Core;

namespace Niobe.Data
{
    public class ReadBlocoDTO : CommomReadEnderecoDTO
    {
        public object Nivel { get; set; }
        public string EnderecoFisico { get; set; }
        public bool Ocupado { get; set; }
    }
}
