using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Domain.Interfaces;

public interface IPieceRepository
{
    Task<Piece?> GetByIdAsync(Guid id);
    Task<IEnumerable<Piece>> GetAllAsync();
    Task AddAsync(Piece piece);
    Task UpdateAsync(Piece piece);
    Task DeleteAsync(Piece piece);
    Task SaveChangesAsync();
}
