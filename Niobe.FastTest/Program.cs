using System;
using System.Collections.Generic;
using System.Linq;
using Niobe.Core;
using Niobe.Data;

namespace Niobe.FastTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GeradorEnderecos gerador = new GeradorEnderecos();

                gerador.IdArmazem = 2;

                gerador.NomeRua = "Rua";
                //gerador.CodigoRua = "R";
                gerador.QuantidadeRua = 6;
                gerador.TipoRua = TipoDado.Numerico;

                gerador.NomeColuna = "Coluna";
                //gerador.CodigoColuna = "C";
                gerador.QuantidadeColuna = 15;
                gerador.TipoColuna = TipoDado.Numerico;

                gerador.NomeNivel = "Nivel";
                //gerador.CodigoNivel = "N";
                gerador.QuantidadeNivel = 15;
                gerador.TipoNivel = TipoDado.Alfanumerico;

                gerador.NomeBloco = "Bloco";
                //gerador.CodigoBloco = "B";
                gerador.QuantidadeBloco = 15;
                gerador.BlocoAB = false;

                gerador.PadraoEndereco = "{Rua}{Coluna}-{Nivel}{Bloco}";

                List<Rua> ruas = gerador.CriarEnderecos();


                AppDbContext appDbContext = new AppDbContext();

                appDbContext.Ruas.AddRange(ruas);

                appDbContext.SaveChanges();

                Console.WriteLine("Tudo Gerado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
