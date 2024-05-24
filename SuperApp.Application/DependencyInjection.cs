using Microsoft.Extensions.DependencyInjection;
using SuperApp.Application.Authentication.Commands.Login;
using SuperApp.Application.Authentication.Commands.Register;
using SuperApp.Application.Heroes.Commands;
using SuperApp.Application.Heroes.Commands.Delete;
using SuperApp.Application.Heroes.Commands.Insert;
using SuperApp.Application.Heroes.Commands.Update;
using SuperApp.Application.Heroes.Queries;

namespace SuperApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IInsertHeroCommand, InsertHeroCommand>();
        services.AddScoped<IUpdateHeroCommand, UpdateHeroCommand>();
        services.AddScoped<IDeleteHeroCommand, DeleteHeroCommand>();
        services.AddScoped<IRegisterUser, RegisterUser>();
        services.AddScoped<ILoginUser, LoginUser>();
        services.AddScoped<IGetAllHeroQuery, GetAllHeroQuery>();
        services.AddScoped<IGetHero, GetHero>();

        return services;
    }
}