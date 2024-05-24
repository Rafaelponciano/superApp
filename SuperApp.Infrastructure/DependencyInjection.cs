using Microsoft.Extensions.DependencyInjection;
using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Infrastructure.Services;
using SuperApp.Repository;

namespace SuperApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IHeroService, HeroService>();
        services.AddScoped<IAutoMapperService, AutoMapperService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddRepository();

        return services;
    }
}