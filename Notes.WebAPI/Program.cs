using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notes.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // инициализация приложения
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                // сервис провайдер, использующийся для разрешения зависимостей
                var serviceProvider = scope.ServiceProvider;

                // получим контекст
                try
                {
                    var context = serviceProvider.GetRequiredService<NotesDbContext>();

                    // вызовем метод инициализации базы
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
