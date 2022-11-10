using Newtonsoft.Json;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Niobe.Data
{
    public class ReadArmazemDTO : CommomReadEnderecoDTO
    {
        public object Filial { get; set; }
    }
}
