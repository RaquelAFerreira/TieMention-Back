using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

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

    public async Task<PaginatedResult<PieceGetFilterDto>> GetPagedAsync(string? name, int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = _context.Piece.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(c => EF.Functions.ILike(c.Name, $"%{name}%"));

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(
                c =>
                    new PieceGetFilterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug
                    }
            )
            .ToListAsync(cancellationToken);

        return new PaginatedResult<PieceGetFilterDto>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items
        };
    }
}