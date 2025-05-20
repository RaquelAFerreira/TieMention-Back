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
        var query =
            from piece in _context.Piece
            join image in _context.Image
                on new { PieceId = piece.Id, Order = 1 } equals new { image.PieceId, image.Order }
                into images
            from img in images.DefaultIfEmpty()
            where string.IsNullOrWhiteSpace(name) || EF.Functions.ILike(piece.Name, $"%{name}%")
            orderby piece.Name
            select new PieceGetFilterDto
            {
                Id = piece.Id,
                Name = piece.Name,
                Slug = piece.Slug,
                ReleaseYear = piece.ReleaseYear,
                Image = img != null ? img.Content : null
            };

        // Obtendo o total de itens (com filtro aplicado)
        var totalItems = await query.CountAsync(cancellationToken);

        // Aplicando paginação
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
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