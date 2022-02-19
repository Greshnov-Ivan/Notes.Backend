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
        // ���������� ���� ��������, ������� ��������� ������������
        public void ConfigureServices(IServiceCollection services)
        {
            // ������� automapper � �������������� ��� ��� ��������� ���� � ������� ������������� ������
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // ������������� ���-��������� ������ � �������� ������� ������
            services.AddCors(options =>
            {
                // ������� CORS ��������� ������ �� ������� � ������������ �������
                // ����������� ���� ������ � ��� ������ ��������� � ���
                // � �������� ���������� ����� ����������
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();

                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ������������� ��������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            // ��������������� � http �� https
            app.UseHttpsRedirection();

            // ������� �������� CORS AllowAll, ������������������ � ConfigureServices
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                // ������� ����� �������� �� �������� ������������ � �� �������
                endpoints.MapControllers();
            });
        }
    }
}