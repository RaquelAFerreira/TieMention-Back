using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;
using TieMention.Infrastructure.Repositories;

namespace TieMention.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddScoped<IMentionRepository, MentionRepository>();
        services.AddScoped<IPieceRepository, PieceRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMentionReadModel, MentionReadModel>();
        services.AddScoped<IPieceReadModel, PieceReadModel>();

        return services;
    }
}
