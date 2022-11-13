using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Niobe.Data;
using Niobe.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Niobe.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                int delay = Convert.ToInt32(config.GetSection("AppSettings")["Delay"])*1000;
                try
                {

                    _logger.LogInformation("Niobe Service running at: {time}", DateTimeOffset.Now);

                    AppDbContext appDbContext = new AppDbContext();

                    var geradors = appDbContext.GeradorEnderešos.Where(g => !g.GeracaoCompletada);

                    foreach (var gerador in geradors)
                    {
                        List<Rua> ruas = gerador.CriarEnderecos();
                        appDbContext.Ruas.AddRange(ruas);

                        gerador.GeracaoCompletada = true;
                        appDbContext.GeradorEnderešos.Update(gerador);
                    }

                    appDbContext.SaveChanges();

                    appDbContext.Dispose();

                }
                catch (Exception ex)
                {
                    _logger.LogError("Erro: " + ex.Message);
                    _logger.LogError("Erro: " + ex.StackTrace);
                }
                await Task.Delay(delay, stoppingToken);
            }
        }
    }
}
