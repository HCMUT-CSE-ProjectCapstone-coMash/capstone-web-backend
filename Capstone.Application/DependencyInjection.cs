using Capstone.Application.Services.Authentication;
using Capstone.Application.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Capstone.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}