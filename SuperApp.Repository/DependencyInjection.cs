using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperApp.Repository.Data;
using SuperApp.Repository.Repositories.HeroRepository;
using SuperApp.Repository.Repositories.UserRepository;

namespace SuperApp.Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IHeroRepository, HeroRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer("Server=localhost,1433; Database=SuperHeroDb; User ID=SA; Password=MyStrongPass123;Encrypt=True;TrustServerCertificate=True;", b => b.MigrationsAssembly("SuperApp.Repository"));
        });

        return services;
    }
}