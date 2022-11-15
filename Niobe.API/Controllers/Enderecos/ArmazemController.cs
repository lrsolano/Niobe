using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Niobe.Core;
using Niobe.Data;
using Niobe.Service;
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
        private ArmazemService _armazemService;

        public ArmazemController(ArmazemService armazemService)
        {
            _armazemService = armazemService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadArmazemDTO), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateArmazemDTO armazemDTO)
        {
            ReadArmazemDTO readDto = _armazemService.Create(armazemDTO);
            
            return CreatedAtAction(nameof(GetById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadArmazemDTO), 200)]
        public IActionResult GetById(int id)
        {
            ReadArmazemDTO readDto = _armazemService.GetById(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReadArmazemDTO>), 200)]
        public IActionResult Get()
        {
            List<ReadArmazemDTO> armazemDTOs =  _armazemService.Get();

            if (armazemDTOs != null) return Ok(armazemDTOs);
            return NotFound();
        }
    }
}
