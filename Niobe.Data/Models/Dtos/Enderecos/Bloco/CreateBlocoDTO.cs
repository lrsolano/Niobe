using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Data
{
    public class CreateBlocoDTO : CommomCreateEnderecoDTO
    {
        [Required]
        public long IdNivel{ get; set; }
        [Required]
        public string EnderecoFisico { get; set; }
    }
}
