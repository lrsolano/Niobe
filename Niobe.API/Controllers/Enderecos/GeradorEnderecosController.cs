using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Core;
using Niobe.Service;
using Niobe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Niobe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class GeradorEnderecosController : ControllerBase
    {
        private GeradorEnderecoService _geradorEnderecoService;

        public GeradorEnderecosController(GeradorEnderecoService geradorEnderecoService)
        {
            _geradorEnderecoService = geradorEnderecoService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateGeradorEnderecos([FromBody] CreateGeradorEnderecoDTO geradorDTO)
        {
            ReadGeradorEnderecoDTO readGeradorEnderecoDTO = _geradorEnderecoService.CreateGeradorEnderecos(geradorDTO);

            
            return CreatedAtAction(nameof(GetGeradorEnderecoById), new { Id = readGeradorEnderecoDTO.Id }, readGeradorEnderecoDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetGeradorEnderecoById(int id)
        {
            ReadGeradorEnderecoDTO readGeradorEnderecoDTO = _geradorEnderecoService.GetGeradorEnderecoById(id);

            if (readGeradorEnderecoDTO != null) return Ok(readGeradorEnderecoDTO);
            
            return NotFound();
        }
    }
}
