using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Data;
using Niobe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niobe.Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            try
            {
                Result resultado = _cadastroService.CadastraUsuario(createUsuarioDto);

                if (resultado.IsFailed) return StatusCode(500);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
