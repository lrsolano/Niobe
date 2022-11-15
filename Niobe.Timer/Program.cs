using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niobe.Service
{
    //sc.exe create "Niobe Timer" binpath="J:\_Projetos\Projeto Niobe\Niobe Service\Niobe.Timer.exe"

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(conf =>
                {
                    conf.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                })
                .UseWindowsService(options =>
                {
                    options.ServiceName = "Niobe Service";
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
