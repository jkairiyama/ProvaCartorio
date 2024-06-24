using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure;
using System.Configuration;
using MapsterMapper;
using Mapster;

//using Microsoft.Extensions.Configuration;
using AppCartorio;

namespace TestCartorio
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();


            string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //string conn = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=Cartorio;";

            //Application.Run(new Form1());
            var host = CreateHostBuilder(conn).Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider? ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder(string conn)
        {

            var builder = Host.CreateDefaultBuilder();
            //var cong = builder.ConfigureAppConfiguration(ConfigurationSection.CreateSection(""));
            return builder
                .ConfigureServices((context, services) =>
                {
                    //services.AddScoped<TInterface, TImplementation>();
                    services
                        .AddAppCartorio()
                        .AddInfrastructure(conn)
                        .AddTransient<Form1>()
                        .AddMapster(); ;

                    //.AddInfrastructure(conn)
                });
        }
    }
}