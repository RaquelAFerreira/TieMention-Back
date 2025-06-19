using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Categories;
using TieMention.Application.Dtos;

namespace TieMention.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
    Task SaveChangesAsync();

    Task<List<CategoryDetailsDto?>> GetAllCategoriesAsync(CancellationToken cancellationToken);
}