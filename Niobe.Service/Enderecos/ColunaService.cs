using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Niobe.Core;
using Niobe.Data;

namespace Niobe.Service
{
    public class ColunaService : IEnderecoCommom<CreateColunaDTO, ReadColunaDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ColunaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ReadColunaDTO Create(CreateColunaDTO createDto)
        {
            Coluna coluna = _mapper.Map<Coluna>(createDto);

            long ordem = (_context.Colunas.Count() > 0) ? _context.Colunas.Select(f => f.Ordem).Max() + 1 : 1;

            coluna.Ordem = ordem;

            _context.Colunas.Add(coluna);
            _context.SaveChanges();

            return _mapper.Map<ReadColunaDTO>(coluna);
        }

        public ReadColunaDTO GetById(int id)
        {
            Coluna coluna = _context.Colunas.FirstOrDefault(coluna => coluna.Id == id);
            if (coluna != null)
            {
                ReadColunaDTO readColunaDTO = _mapper.Map<ReadColunaDTO>(coluna);
                return readColunaDTO;
            }

            return null;
        }

        public List<ReadColunaDTO> Get()
        {
            List<Coluna> coluna = _context.Colunas.Where(a => a.Ativo).OrderByDescending(a => a.Id).Take(100).ToList();
            if (coluna != null)
            {
                List<ReadColunaDTO> readColunaDTOs = _mapper.Map<List<ReadColunaDTO>>(coluna);
                return readColunaDTOs;
            }
            return null;
        }
        public List<ReadColunaDTO> GetByRua(int id)
        {
            List<Coluna> coluna = _context.Colunas.Where(a => a.Ativo && a.IdRua == id).OrderBy(a => a.Ordem).ToList();
            if (coluna != null)
            {
                List<ReadColunaDTO> readColunaDTOs = _mapper.Map<List<ReadColunaDTO>>(coluna);
                return readColunaDTOs;
            }
            return null;
        }
        public List<ReadColunaDTO> GetByArmazem(int id)
        {
            List<Coluna> coluna = _context.Colunas.Where(a => a.Ativo && a.Rua.IdArmazem == id).OrderBy(a => a.Ordem).ToList();
            if (coluna != null)
            {
                List<ReadColunaDTO> readColunaDTOs = _mapper.Map<List<ReadColunaDTO>>(coluna);
                return readColunaDTOs;
            }
            return null;
        }
    }
}
