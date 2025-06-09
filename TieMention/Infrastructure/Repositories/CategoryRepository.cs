using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;
using TieMention.Application.Dtos.Categories;
using TieMention.Application.Dtos;

namespace TieMention.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Category.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Category.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Category.AddAsync(category);
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Category.Update(category);
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Category.Remove(category);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<CategoryGetDto?>> GetAllCategoriesAsync(
        CancellationToken cancellationToken
    )
    {
        var query =
            from category in _context.Category
            select new CategoryGetDto { Id = category.Id, Description = category.Description };

        return await query.ToListAsync(cancellationToken);
    }
}
