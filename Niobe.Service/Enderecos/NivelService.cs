using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Niobe.Core;
using Niobe.Data;

namespace Niobe.Service
{
    public class NivelService : IEnderecoCommom<CreateNivelDTO, ReadNivelDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public NivelService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ReadNivelDTO Create(CreateNivelDTO createDto)
        {
            Nivel nivel = _mapper.Map<Nivel>(createDto);

            long ordem = (_context.Nivel.Count() > 0) ? _context.Nivel.Select(f => f.Ordem).Max() + 1 : 1;

            nivel.Ordem = ordem;

            _context.Nivel.Add(nivel);
            _context.SaveChanges();

            return _mapper.Map<ReadNivelDTO>(nivel);
        }

        public ReadNivelDTO GetById(int id)
        {
            Nivel nivel = _context.Nivel.FirstOrDefault(nivel => nivel.Id == id);
            if (nivel != null)
            {
                ReadNivelDTO readNivelDTO = _mapper.Map<ReadNivelDTO>(nivel);
                return readNivelDTO;
            }

            return null;
        }

        public List<ReadNivelDTO> Get()
        {
            List<Nivel> nivel = _context.Nivel.Where(a => a.Ativo).OrderByDescending(a => a.Id).Take(100).ToList();
            if (nivel != null)
            {
                List<ReadNivelDTO> readNivelDTOs = _mapper.Map<List<ReadNivelDTO>>(nivel);
                return readNivelDTOs;
            }
            return null;
        }
    }
}
