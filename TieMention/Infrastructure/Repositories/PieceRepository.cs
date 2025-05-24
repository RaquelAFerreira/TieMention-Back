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

    public async Task<PieceGetByIdDto?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query =
            from piece in _context.Piece
            join image in _context.Image
                on new { PieceId = piece.Id, Order = 1 } equals new { image.PieceId, image.Order }
                into images
            from img in images.DefaultIfEmpty()
            join category in _context.Category
                on new { Id = piece.Category } equals new { category.Id }
                into categorys
            from ctg in categorys.DefaultIfEmpty()
            where piece.Id == id  // Filtro pelo ID da peça
            select new PieceGetByIdDto
            {
                Id = piece.Id,
                Name = piece.Name,
                Slug = piece.Slug,
                ReleaseYear = piece.ReleaseYear,
                Description = piece.Description,
                Category = ctg.Description,
                Image = img != null ? img.Content : null
            };

        // Obtendo um único registro
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PaginatedResult<PieceGetByIdDto>> GetPagedAsync(string? name, int page, int pageSize, CancellationToken cancellationToken)
    {
        var query =
            from piece in _context.Piece
            join image in _context.Image
                on new { PieceId = piece.Id, Order = 1 } equals new { image.PieceId, image.Order }
                into images
            from img in images.DefaultIfEmpty()
            join category in _context.Category
                on new { Id = piece.Category } equals new { category.Id }
                into categorys
            from ctg in categorys.DefaultIfEmpty()
            where string.IsNullOrWhiteSpace(name) || EF.Functions.ILike(piece.Name, $"%{name}%")
            orderby piece.Name
            select new PieceGetByIdDto
            {
                Id = piece.Id,
                Name = piece.Name,
                Slug = piece.Slug,
                ReleaseYear = piece.ReleaseYear,
                Description = piece.Description,
                Category = ctg.Description,
                Image = img != null ? img.Content : null
            };

        // Obtendo o total de itens (com filtro aplicado)
        var totalItems = await query.CountAsync(cancellationToken);

        // Aplicando paginação
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<PieceGetByIdDto>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items
        };
    }
}