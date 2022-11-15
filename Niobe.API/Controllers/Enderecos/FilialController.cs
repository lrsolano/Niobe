using AutoMapper;
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
    [ApiController]
    [Route("[controller]")]
    public class FilialController : ControllerBase
    {

        private FilialService _filialService;

        public FilialController(FilialService filialService)
        {
            _filialService = filialService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(Filial), 200)]
        [Route("create")]
        public IActionResult Create([FromBody] CreateFilialDTO filialDTO)
        {
            ReadFilialDTO readFilialDTO = _filialService.Create(filialDTO);
            
            return CreatedAtAction(nameof(GetById), new { Id = readFilialDTO.Id }, readFilialDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReadFilialDTO readFilialDTO = _filialService.GetById(id);
            if (readFilialDTO != null) return Ok(readFilialDTO);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ReadFilialDTO> filialDTO = _filialService.Get();

            if (filialDTO != null) return Ok(filialDTO);

            return NotFound();
        }
    }
}
