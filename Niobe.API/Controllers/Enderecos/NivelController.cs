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
    public class NivelController : ControllerBase
    {
        private NivelService _nivelService;

        public NivelController(NivelService nivelService)
        {
            _nivelService = nivelService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadNivelDTO), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateNivelDTO nivelDTO)
        {
            ReadNivelDTO readDto = _nivelService.Create(nivelDTO);

            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadNivelDTO), 200)]
        public IActionResult GetById(int id)
        {
            ReadNivelDTO readDto = _nivelService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("armazem/{id}")]
        [ProducesResponseType(typeof(ReadNivelDTO), 200)]
        public IActionResult GetByArmazem(int id)
        {
            List<ReadNivelDTO> listDTOs = _nivelService.GetByArmazem(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("rua/{id}")]
        [ProducesResponseType(typeof(ReadNivelDTO), 200)]
        public IActionResult GetByRua(int id)
        {
            List<ReadNivelDTO> listDTOs = _nivelService.GetByRua(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("coluna/{id}")]
        [ProducesResponseType(typeof(ReadNivelDTO), 200)]
        public IActionResult GetByColuna(int id)
        {
            List<ReadNivelDTO> listDTOs = _nivelService.GetByColuna(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadNivelDTO>), 200)]
        public IActionResult Get()
        {
            List<ReadNivelDTO> listDTOs = _nivelService.Get();

            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }
    }
}
