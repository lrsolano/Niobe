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
    public class RuaController : ControllerBase
    {
        private RuaService _ruaService;

        public RuaController(RuaService ruaService)
        {
            _ruaService = ruaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadRuaDTO), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateRuaDTO ruaDTO)
        {
            ReadRuaDTO readDto = _ruaService.Create(ruaDTO);

            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadRuaDTO), 200)]
        public IActionResult GetById(int id)
        {
            ReadRuaDTO readDto = _ruaService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("armazem/{id}")]
        [ProducesResponseType(typeof(ReadRuaDTO), 200)]
        public IActionResult GetByArmazem(int id)
        {
            List<ReadRuaDTO> listDTOs = _ruaService.GetByArmazem(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadRuaDTO>), 200)]
        public IActionResult Get()
        {
            List<ReadRuaDTO> listDTOs = _ruaService.Get();

            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }
    }
}
