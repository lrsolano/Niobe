using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Core;
using Niobe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niobe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeradorEnderecosController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GeradorEnderecosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateGeradorEnderecos([FromBody] CreateGeradorEnderecoDTO geradorDTO)
        {
            GeradorEnderecos gerador = _mapper.Map<GeradorEnderecos>(geradorDTO);

            _context.GeradorEndereços.Add(gerador);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGeradorEnderecoById), new { Id = gerador.Id }, gerador);
        }

        [HttpGet("{id}")]
        public IActionResult GetGeradorEnderecoById(int id)
        {
            GeradorEnderecos gerador = _context.GeradorEndereços.FirstOrDefault(gerador => gerador.Id == id);
            if (gerador != null)
            {
                ReadGeradorEnderecoDTO geradorEnderecoDTO = _mapper.Map<ReadGeradorEnderecoDTO>(gerador);
                return Ok(geradorEnderecoDTO);
            }
            return NotFound();
        }
    }
}
