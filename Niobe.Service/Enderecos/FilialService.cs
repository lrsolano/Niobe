using AutoMapper;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Niobe.Service
{
    public class FilialService : IEnderecoCommom<CreateFilialDTO, ReadFilialDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilialDTO Create(CreateFilialDTO filialDTO)
        {
            Filial filial = _mapper.Map<Filial>(filialDTO);

            long ordem = _context.Filiais.Select(f => f.Ordem).Max() + 1;

            filial.Ordem = ordem;

            _context.Filiais.Add(filial);
            _context.SaveChanges();

            return _mapper.Map<ReadFilialDTO>(filial);
        }

        public ReadFilialDTO GetById(int id)
        {
            Filial filial = _context.Filiais.FirstOrDefault(filia => filia.Id == id);
            if (filial != null)
            {
                ReadFilialDTO filialDTO = _mapper.Map<ReadFilialDTO>(filial);
                return filialDTO;
            }
            return null;
        }

        public List<ReadFilialDTO> Get()
        {
            List<Filial> filial = _context.Filiais.Where(f => f.Ativo).ToList();
            if (filial != null)
            {
                List<ReadFilialDTO> filialDTO = _mapper.Map<List<ReadFilialDTO>>(filial);
                return filialDTO;
            }
            return null;
        }
    }
}
