using AutoMapper;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niobe.Service
{
    public class ArmazemService : IEnderecoCommom<CreateArmazemDTO, ReadArmazemDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ArmazemService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadArmazemDTO Create(CreateArmazemDTO armazemDTO)
        {
            Armazem armazem = _mapper.Map<Armazem>(armazemDTO);

            long ordem = (_context.Armazems.Count() > 0) ? _context.Armazems.Select(f => f.Ordem).Max() + 1 : 1;

            armazem.Ordem = ordem;

            _context.Armazems.Add(armazem);
            _context.SaveChanges();

            return _mapper.Map<ReadArmazemDTO>(armazem);
        }

        public ReadArmazemDTO GetById(int id)
        {
            Armazem armazem = _context.Armazems.FirstOrDefault(armazem => armazem.Id == id);
            if (armazem != null)
            {
                ReadArmazemDTO readArmazemDTO = _mapper.Map<ReadArmazemDTO>(armazem);
                return readArmazemDTO;
            }

            return null;
        }

        public List<ReadArmazemDTO> Get()
        {
            List<Armazem> armazem = _context.Armazems.Where(a => a.Ativo).ToList();
            if (armazem != null)
            {
                List<ReadArmazemDTO> readArmazemDTOs = _mapper.Map<List<ReadArmazemDTO>>(armazem);
                return readArmazemDTOs;
            }
            return null;
        }
    }
}
