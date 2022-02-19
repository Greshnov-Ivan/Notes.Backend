using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Медиатор меет свой метод добавление самого себя
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
