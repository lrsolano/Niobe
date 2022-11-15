using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Niobe.Core;
using Niobe.Data;

namespace Niobe.Service
{
    public class BlocoService : IEnderecoCommom<CreateBlocoDTO, ReadBlocoDTO>
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public BlocoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public ReadBlocoDTO Create(CreateBlocoDTO createDto)
        {
            Bloco bloco = _mapper.Map<Bloco>(createDto);

            long ordem = (_context.Blocos.Count() > 0) ? _context.Blocos.Select(f => f.Ordem).Max() + 1 : 1;

            bloco.Ordem = ordem;

            _context.Blocos.Add(bloco);
            _context.SaveChanges();

            return _mapper.Map<ReadBlocoDTO>(bloco);
        }

        public ReadBlocoDTO GetById(int id)
        {
            Bloco bloco = _context.Blocos.FirstOrDefault(bloco => bloco.Id == id);
            if (bloco != null)
            {
                ReadBlocoDTO readBlocoDTO = _mapper.Map<ReadBlocoDTO>(bloco);
                return readBlocoDTO;
            }

            return null;
        }

        public List<ReadBlocoDTO> Get()
        {
            List<Bloco> bloco = _context.Blocos.Where(a => a.Ativo).OrderByDescending(a => a.Id).Take(100).ToList();
            if (bloco != null)
            {
                List<ReadBlocoDTO> readBlocoDTOs = _mapper.Map<List<ReadBlocoDTO>>(bloco);
                return readBlocoDTOs;
            }
            return null;
        }

        public List<ReadBlocoDTO> GetByNivel(int idNivel)
        {
            List<Bloco> bloco = _context.Blocos.Where(a => a.Ativo && a.IdNivel == idNivel).OrderBy(a => a.Ordem).ToList();
            if (bloco != null)
            {
                List<ReadBlocoDTO> readBlocoDTOs = _mapper.Map<List<ReadBlocoDTO>>(bloco);
                return readBlocoDTOs;
            }
            return null;
        }
        public List<ReadBlocoDTO> GetByColuna(int idColuna)
        {
            List<Bloco> bloco = _context.Blocos.Where(a => a.Ativo && a.Nivel.IdColuna == idColuna).OrderBy(a => a.Ordem).ToList();
            if (bloco != null)
            {
                List<ReadBlocoDTO> readBlocoDTOs = _mapper.Map<List<ReadBlocoDTO>>(bloco);
                return readBlocoDTOs;
            }
            return null;
        }
        public List<ReadBlocoDTO> GetByRua(int idRua)
        {
            List<Bloco> bloco = _context.Blocos.Where(a => a.Ativo && a.Nivel.Coluna.IdRua == idRua).OrderBy(a => a.Ordem).ToList();
            if (bloco != null)
            {
                List<ReadBlocoDTO> readBlocoDTOs = _mapper.Map<List<ReadBlocoDTO>>(bloco);
                return readBlocoDTOs;
            }
            return null;
        }
        public List<ReadBlocoDTO> GetByArmazem(int idArmazem)
        {
            List<Bloco> bloco = _context.Blocos.Where(a => a.Ativo && a.Nivel.Coluna.Rua.IdArmazem == idArmazem).OrderBy(a => a.Ordem).ToList();
            if (bloco != null)
            {
                List<ReadBlocoDTO> readBlocoDTOs = _mapper.Map<List<ReadBlocoDTO>>(bloco);
                return readBlocoDTOs;
            }
            return null;
        }
    }
}
