using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Domain.Interfaces;

public interface IImageRepository
{
    Task<Image?> GetByIdAsync(Guid id);
    Task<IEnumerable<Image>> GetAllAsync();
    Task AddAsync(Image image);
    Task UpdateAsync(Image image);
    Task DeleteAsync(Image image);
    Task SaveChangesAsync();
}