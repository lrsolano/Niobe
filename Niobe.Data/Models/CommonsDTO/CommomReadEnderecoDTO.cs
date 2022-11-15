using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public abstract class CommomReadEnderecoDTO
    {
        [Display(Order = -10)]
        public long Id { get; set; }
        [Display(Order = -10)]
        public string Codigo { get; set; }
        [Display(Order = -10)]
        public string Nome { get; set; }
        [Display(Order = -10)]
        public bool Ativo { get; set; }
        [Display(Order = -10)]
        public long Ordem { get; set; }
    }
}
