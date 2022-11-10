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
    public class ArmazemController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ArmazemController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Armazem), 200)]
        [Route("create")]
        public IActionResult CreateFilial([FromBody] CreateArmazemDTO armazemDTO)
        {
            Armazem Armazem = _mapper.Map<Armazem>(armazemDTO);

            long ordem = (_context.Armazems.Count() > 0) ? _context.Armazems.Select(f => f.Ordem).Max() + 1 : 1;

            Armazem.Ordem = ordem;

            _context.Armazems.Add(Armazem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetArmazemById), new { Id = Armazem.Id }, Armazem);
        }

        [HttpGet("{id}")]
        public IActionResult GetArmazemById(int id)
        {
            Armazem armazem = _context.Armazems.FirstOrDefault(armazem => armazem.Id == id);
            if (armazem != null)
            {
                ReadArmazemDTO readArmazemDTO = _mapper.Map<ReadArmazemDTO>(armazem);
                return Ok(readArmazemDTO);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetArmazem()
        {
            List<Armazem> armazem = _context.Armazems.Where(a => a.Ativo).ToList();
            if (armazem != null)
            {
                List<ReadArmazemDTO> readArmazemDTOs = _mapper.Map<List<ReadArmazemDTO>>(armazem);
                return Ok(readArmazemDTOs);
            }
            return NotFound();
        }
    }
}
