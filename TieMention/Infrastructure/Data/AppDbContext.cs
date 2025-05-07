using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;

namespace TieMention.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mention> Mentions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações do modelo
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}