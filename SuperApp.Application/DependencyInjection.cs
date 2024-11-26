using Microsoft.Extensions.DependencyInjection;
using SuperApp.Application.Authentication.Commands.Login;
using SuperApp.Application.Authentication.Commands.Register;
using SuperApp.Application.Heroes.Commands;
using SuperApp.Application.Heroes.Commands.Delete;
using SuperApp.Application.Heroes.Commands.Insert;
using SuperApp.Application.Heroes.Commands.Update;
using SuperApp.Application.Heroes.Queries;
using SuperApp.Application.Users.Commands.Delete;
using SuperApp.Application.Users.Commands.Insert;
using SuperApp.Application.Users.Commands.Update;
using SuperApp.Application.Users.Queries.GetAllUsers;
using SuperApp.Application.Users.Queries.GetUser;

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
        services.AddScoped<IInsertUserCommand, InsertUserCommand>();
        services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();
        services.AddScoped<IDeleteUserCommand, DeleteUserCommand>();
        services.AddScoped<IGetAllUsersQuery, GetAllUsersQuery>();
        services.AddScoped<IGetUserQuery, GetUserQuery>();

        return services;
    }
}