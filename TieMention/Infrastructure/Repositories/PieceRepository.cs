using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;

namespace TieMention.Infrastructure.Repositories;

public class PieceRepository : IPieceRepository
{
    private readonly AppDbContext _context;

    public PieceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Piece?> GetByIdAsync(Guid id)
    {
        return await _context.Piece.FindAsync(id);
    }

    public async Task<IEnumerable<Piece>> GetAllAsync()
    {
        return await _context.Piece.ToListAsync();
    }

    public async Task AddAsync(Piece piece)
    {
        await _context.Piece.AddAsync(piece);
    }

    public async Task UpdateAsync(Piece piece)
    {
        _context.Piece.Update(piece);
    }

    public async Task DeleteAsync(Piece piece)
    {
        _context.Piece.Remove(piece);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}