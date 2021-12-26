using DiverseTraining.Interface;
using DiverseTraining.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DiverseTraining.Extension
{
    public static class InterfaceServiceExtension
    {
        //Interface services extension
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }          
    }
}