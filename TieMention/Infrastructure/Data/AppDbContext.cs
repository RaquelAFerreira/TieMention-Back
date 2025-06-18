using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;

namespace TieMention.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mention> Mention { get; set; }
    
    public DbSet<Piece> Piece { get; set; }

    public DbSet<Image> Image { get; set; }

    public DbSet<Category> Category { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}