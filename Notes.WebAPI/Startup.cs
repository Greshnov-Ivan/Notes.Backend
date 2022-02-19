using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Application;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Persistence;
using System.Reflection;

namespace Notes.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // Добавление всех сервисов, которые планируем использовать
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавим automapper и сконфигурируем его для получения инфо о текущей выполняющейся сборке
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // Предоставляет веб-страницам доступ к ресурсам другого домена
            services.AddCors(options =>
            {
                // Включим CORS заголовок ответа от сервера и сформулируем правило
                // позволяющее кому угодно и как угодно стучаться к нам
                // В реальном приложение НУЖНО ОГРАНИЧИТЬ
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();

                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Настраивается конвейер
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            // Перенаправление с http на https
            app.UseHttpsRedirection();

            // Добавим политику CORS AllowAll, сконфигурированную в ConfigureServices
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                // Роутинг будет мапиться на названия контроллеров и их методов
                endpoints.MapControllers();
            });
        }
    }
}
