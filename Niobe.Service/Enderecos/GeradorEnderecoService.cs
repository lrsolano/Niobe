using AutoMapper;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using FluentResults;
using System.Text;

namespace Niobe.Service
{
    public class GeradorEnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GeradorEnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGeradorEnderecoDTO CreateGeradorEnderecos(CreateGeradorEnderecoDTO geradorDTO)
        {
            GeradorEnderecos gerador = _mapper.Map<GeradorEnderecos>(geradorDTO);

            _context.GeradorEndereços.Add(gerador);
            _context.SaveChanges();

            return _mapper.Map<ReadGeradorEnderecoDTO>(gerador);
        }

        public ReadGeradorEnderecoDTO GetGeradorEnderecoById(int id)
        {
            GeradorEnderecos gerador = _context.GeradorEndereços.FirstOrDefault(gerador => gerador.Id == id);
            if (gerador != null)
            {
                ReadGeradorEnderecoDTO geradorEnderecoDTO = _mapper.Map<ReadGeradorEnderecoDTO>(gerador);
                return geradorEnderecoDTO;
            }

            return null;
        }

        public void CreatEnderecos()
        {
            var geradors = _context.GeradorEndereços.Where(g => !g.GeracaoCompletada);

            foreach (var gerador in geradors)
            {
                List<Rua> ruas = gerador.CriarEnderecos();
                _context.Ruas.AddRange(ruas);

                gerador.GeracaoCompletada = true;
                _context.GeradorEndereços.Update(gerador);
            }

            _context.SaveChanges();

        }
    }
}
