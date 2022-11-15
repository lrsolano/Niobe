using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Data;
using Niobe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niobe.API.Controllers.Enderecos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColunaController : ControllerBase
    {
        private ColunaService _colunaService;

        public ColunaController(ColunaService colunaService)
        {
            _colunaService = colunaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadColunaDTO), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateColunaDTO colunaDTO)
        {
            ReadColunaDTO readDto = _colunaService.Create(colunaDTO);

            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadColunaDTO), 200)]
        public IActionResult GetById(int id)
        {
            ReadColunaDTO readDto = _colunaService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("armazem/{id}")]
        [ProducesResponseType(typeof(ReadColunaDTO), 200)]
        public IActionResult GetByArmazem(int id)
        {
            List<ReadColunaDTO> listDTOs = _colunaService.GetByArmazem(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("rua/{id}")]
        [ProducesResponseType(typeof(ReadColunaDTO), 200)]
        public IActionResult GetByRua(int id)
        {
            List<ReadColunaDTO> listDTOs = _colunaService.GetByRua(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadColunaDTO>), 200)]
        public IActionResult Get()
        {
            List<ReadColunaDTO> listDTOs = _colunaService.Get();

            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }
    }
}
