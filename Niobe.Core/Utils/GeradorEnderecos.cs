using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Niobe.Core
{
    public class GeradorEnderecos
    {
        public long Id { get; set; }
        [Required]
        public long IdArmazem { get; set; }
        [Required]
        public string NomeRua { get; set; }
        public string CodigoRua { get; set; }
        [Required]
        public TipoDado TipoRua { get; set; }
        [Required]
        public long QuantidadeRua { get; set; }
        [Required]
        public string NomeColuna { get; set; }
        public string CodigoColuna { get; set; }
        [Required]
        public TipoDado TipoColuna { get; set; }
        [Required]
        public long QuantidadeColuna { get; set; }
        [Required]
        public string NomeNivel { get; set; }
        public string CodigoNivel { get; set; }
        [Required]
        public TipoDado TipoNivel { get; set; }
        [Required]
        public long QuantidadeNivel { get; set; }
        [Required]
        public string NomeBloco { get; set; }
        public string CodigoBloco{ get; set; }
        public bool BlocoAB { get; set; } = false;
        [Required]
        public long QuantidadeBloco { get; set; }
        [Required]
        public string PadraoEndereco { get; set; }

        public long OrdemRua { get; set; }
        public long OrdemColuna { get; set; }
        public long OrdemNivel { get; set; }
        public long OrdemBloco { get; set; }

        public bool GeracaoCompletada { get; set; } = false;

        private const int INICIO_ALFA = 65;

        public List<Rua> CriarEnderecos()
        {
            List<Rua> ruas = new List<Rua>();

            if (TipoRua == TipoDado.Alfanumerico && QuantidadeRua > 26) throw new Exception("Rua alfanumerica só pode até 26");
            if (TipoColuna == TipoDado.Alfanumerico && QuantidadeRua > 26) throw new Exception("Coluna alfanumerica só pode até 26");
            if (TipoNivel == TipoDado.Alfanumerico && QuantidadeRua > 26) throw new Exception("Nivel alfanumerica só pode até 26");
            if (!PadraoEndereco.Contains("{Rua}") || !PadraoEndereco.Contains("{Coluna}") || !PadraoEndereco.Contains("{Nivel}") || !PadraoEndereco.Contains("{Bloco}")) throw new Exception("Defina um padrão para o endereço fisico válido");

            QuantidadeBloco = (BlocoAB) ? QuantidadeBloco * 2 : QuantidadeBloco;;


            for (int r = 0; r < QuantidadeRua; r++)
            {
                string codigoRua = (TipoRua == TipoDado.Alfanumerico) ? Convert.ToString((char)(INICIO_ALFA + r)) : (r+1).ToString();

                Rua rua = new Rua();

                rua.IdArmazem = IdArmazem;
                rua.Nome = string.Format($"{NomeRua} {codigoRua}").Trim();
                rua.Codigo = string.Format($"{CodigoRua}{codigoRua}").Trim();
                rua.Ordem = OrdemRua++;
                rua.Colunas = new List<Coluna>();
                for (int c = 0; c <  QuantidadeColuna; c++)
                {
                    string codigoColuna = (TipoColuna == TipoDado.Alfanumerico) ? Convert.ToString((char)(INICIO_ALFA + c)) : (c+1).ToString();

                    Coluna coluna = new Coluna();

                    coluna.Nome = string.Format($"{NomeColuna} {codigoColuna}").Trim();
                    coluna.Codigo = string.Format($"{CodigoColuna}{codigoColuna}").Trim();
                    coluna.Ordem = OrdemColuna++;
                    coluna.Niveis = new List<Nivel>();
                    for (int n = 0; n < QuantidadeNivel; n++)
                    {
                        string codigoNivel = (TipoColuna == TipoDado.Alfanumerico) ? Convert.ToString((char)(INICIO_ALFA + n)) : (n+1).ToString();

                        Nivel nivel = new Nivel();

                        nivel.Nome = string.Format($"{NomeNivel} {codigoNivel}").Trim();
                        nivel.Codigo = string.Format($"{CodigoNivel}{codigoNivel}").Trim();
                        nivel.Ordem = OrdemNivel++;
                        nivel.Blocos = new List<Bloco>();
                        for (int b = 1; b < QuantidadeBloco+1; b++)
                        {
                            string codigoBloco = string.Empty;

                            if (BlocoAB && (b % 2 == 0))
                            {
                                codigoBloco = string.Format($"{b}B").Trim();
                            }
                            else if (BlocoAB && (b % 2 != 0))
                            {
                                codigoBloco = string.Format($"{b}A").Trim();
                            }
                            else
                            {
                                codigoBloco = string.Format($"{b}").Trim();
                            }

                            Bloco bloco = new Bloco();
                            bloco.Codigo = string.Format($"{CodigoBloco}{codigoBloco}").Trim();
                            bloco.Nome = string.Format($"{NomeBloco}  {codigoBloco}").Trim();
                            bloco.Ordem = OrdemBloco++;
                            bloco.EnderecoFisico = PadraoEndereco.Replace("{Rua}", rua.Codigo).Replace("{Coluna}", coluna.Codigo).Replace("{Nivel}", nivel.Codigo).Replace("{Bloco}", bloco.Codigo);

                            nivel.Blocos.Add(bloco);
                        }

                        coluna.Niveis.Add(nivel);
                    }

                    rua.Colunas.Add(coluna);
                }

                ruas.Add(rua);
            }

            return ruas;
        }

    }
}
