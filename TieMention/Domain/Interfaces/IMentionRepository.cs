using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Mentions;


namespace TieMention.Domain.Interfaces;

public interface IMentionRepository
{
    Task<Mention?> GetByIdAsync(Guid id);
    Task<IEnumerable<Mention>> GetAllAsync();
    Task AddAsync(Mention mention);
    Task UpdateAsync(Mention mention);
    Task DeleteAsync(Mention mention);
    Task SaveChangesAsync();
}
