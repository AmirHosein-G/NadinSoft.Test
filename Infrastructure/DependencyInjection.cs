using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entiys;
using Infrastructure.Authentication;
using Infrastructure.ReadRepository;
using Infrastructure.WriteRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("ApiConnectionString"));
        }, ServiceLifetime.Scoped);
        services.AddDbContext<AuthenticationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("AuthenticationConnectionString"));
        }, ServiceLifetime.Scoped);

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityReadRepository, IdentityReadRepository>();
        services.AddScoped<IIdentityWriteRepository, IdentityWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }

}
