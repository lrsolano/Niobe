using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Niobe.Core;
using Niobe.Data;

namespace Niobe.Service
{
    public class RuaService : IEnderecoCommom<CreateRuaDTO, ReadRuaDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RuaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ReadRuaDTO Create(CreateRuaDTO createDto)
        {
            Rua rua = _mapper.Map<Rua>(createDto);

            long ordem = (_context.Ruas.Count() > 0) ? _context.Ruas.Select(f => f.Ordem).Max() + 1 : 1;

            rua.Ordem = ordem;

            _context.Ruas.Add(rua);
            _context.SaveChanges();

            return _mapper.Map<ReadRuaDTO>(rua);
        }

        public ReadRuaDTO GetById(int id)
        {
            Rua rua = _context.Ruas.FirstOrDefault(rua => rua.Id == id);
            if (rua != null)
            {
                ReadRuaDTO readRuaDTO = _mapper.Map<ReadRuaDTO>(rua);
                return readRuaDTO;
            }

            return null;
        }

        public List<ReadRuaDTO> Get()
        {
            List<Rua> rua = _context.Ruas.Where(a => a.Ativo).OrderByDescending(a => a.Id).Take(100).ToList();
            if (rua != null)
            {
                List<ReadRuaDTO> readRuaDTOs = _mapper.Map<List<ReadRuaDTO>>(rua);
                return readRuaDTOs;
            }
            return null;
        }

        public List<ReadRuaDTO> GetByArmazem(int id)
        {
            List<Rua> rua = _context.Ruas.Where(a => a.Ativo && a.IdArmazem == id).OrderBy(a => a.Ordem).ToList();
            if (rua != null)
            {
                List<ReadRuaDTO> readRuaDTOs = _mapper.Map<List<ReadRuaDTO>>(rua);
                return readRuaDTOs;
            }
            return null;
        }
    }
}
