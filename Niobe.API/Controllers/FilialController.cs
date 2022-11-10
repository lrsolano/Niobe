using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Niobe.Core;
using Niobe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niobe.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilialController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilialController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Filial), 200)]
        [Route("create")]
        public IActionResult CreateFilial([FromBody] CreateFilialDTO filialDTO)
        {
            Filial filial = _mapper.Map<Filial>(filialDTO);

            long ordem = _context.Filiais.Select(f => f.Ordem).Max() + 1;

            filial.Ordem = ordem;

            _context.Filiais.Add(filial);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilialById), new { Id = filial.Id }, filial);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilialById(int id)
        {
            Filial filial = _context.Filiais.FirstOrDefault(filia => filia.Id == id);
            if (filial != null)
            {
                ReadFilialDTO filialDTO = _mapper.Map<ReadFilialDTO>(filial);
                return Ok(filialDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetFilial()
        {
            List<Filial> filial = _context.Filiais.Where(f => f.Ativo).ToList();
            if (filial != null)
            {
                List<ReadFilialDTO> filialDTO = _mapper.Map<List<ReadFilialDTO>>(filial);
                return Ok(filialDTO);
            }
            return NotFound();
        }
    }
}
