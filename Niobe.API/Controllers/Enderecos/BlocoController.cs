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
    public class BlocoController : ControllerBase
    {
        private BlocoService _blocoService;

        public BlocoController(BlocoService blocoService)
        {
            _blocoService = blocoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateBlocoDTO blocoDTO)
        {
            ReadBlocoDTO readDto = _blocoService.Create(blocoDTO);

            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        public IActionResult GetById(int id)
        {
            ReadBlocoDTO readDto = _blocoService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("armazem/{id}")]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        public IActionResult GetByArmazem(int id)
        {
            List<ReadBlocoDTO> listDTOs = _blocoService.GetByArmazem(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("rua/{id}")]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        public IActionResult GetByRua(int id)
        {
            List<ReadBlocoDTO> listDTOs = _blocoService.GetByRua(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("coluna/{id}")]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        public IActionResult GetByColuna(int id)
        {
            List<ReadBlocoDTO> listDTOs = _blocoService.GetByColuna(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet("nivel/{id}")]
        [ProducesResponseType(typeof(ReadBlocoDTO), 200)]
        public IActionResult GetByNivel(int id)
        {
            List<ReadBlocoDTO> listDTOs = _blocoService.GetByNivel(id);
            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadBlocoDTO>), 200)]
        public IActionResult Get()
        {
            List<ReadBlocoDTO> listDTOs = _blocoService.Get();

            if (listDTOs != null) return Ok(listDTOs);
            return NotFound();
        }
    }
}
