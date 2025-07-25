using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;
using TieMention.Application.Dtos.Mentions;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Infrastructure.Repositories;

public class MentionRepository : IMentionRepository
{
    private readonly AppDbContext _context;

    public MentionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Mention?> GetByIdAsync(Guid id)
    {
        return await _context.Mention.FindAsync(id);
    }

    public async Task<IEnumerable<Mention>> GetAllAsync()
    {
        return await _context.Mention.ToListAsync();
    }

    public async Task AddAsync(Mention mention)
    {
        await _context.Mention.AddAsync(mention);
    }

    public async Task UpdateAsync(Mention mention)
    {
        _context.Mention.Update(mention);
    }

    public async Task DeleteAsync(Mention mention)
    {
        _context.Mention.Remove(mention);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<MentionDetailsDto?> GetMentionByIdAsync(
        string Slug,
        CancellationToken cancellationToken
    )
    {
        var query =
            from mention in _context.Mention
            where mention.Slug == Slug
            join mentioned in _context.Piece on mention.MentionedPieceId equals mentioned.Id
            join mentionedCategory in _context.Category
                on mentioned.Category equals mentionedCategory.Id
            join mentioner in _context.Piece on mention.MentionerPieceId equals mentioner.Id
            join mentionerCategory in _context.Category
                on mentioner.Category equals mentionerCategory.Id 
            join mentionedImage in _context.Image
                on new { PieceId = mentioned.Id, Order = 1 } equals new
                {
                    mentionedImage.PieceId,
                    mentionedImage.Order
                }
                into mentionedImages
            from mentionedImg in mentionedImages.DefaultIfEmpty()
            join mentionerImage in _context.Image
                on new { PieceId = mentioner.Id, Order = 1 } equals new
                {
                    mentionerImage.PieceId,
                    mentionerImage.Order
                }
                into mentionerImages
            from mentionerImg in mentionerImages.DefaultIfEmpty()
            join mentionImage in _context.Image
                on mention.Id equals mentionImage.PieceId 
                into mentionImages
            from mImg in mentionImages.Where(img => img.Order == 1).DefaultIfEmpty()
            select new MentionDetailsDto
            {
                Id = mention.Id,
                Description = mention.Description,
                Image = mImg != null ? mImg.Content : null,
                MentionedPiece = new PieceDetailsDto
                {
                    Id = mentioned.Id,
                    Name = mentioned.Name,
                    Slug = mentioned.Slug,
                    ReleaseYear = mentioned.ReleaseYear,
                    Category = mentionedCategory.Description,
                    Image = mentionedImg != null ? mentionedImg.Content : null
                },
                MentionerPiece = new PieceDetailsDto
                {
                    Id = mentioner.Id,
                    Name = mentioner.Name,
                    Slug = mentioner.Slug,
                    ReleaseYear = mentioner.ReleaseYear,
                    Category = mentionerCategory.Description,
                    Image = mentionerImg != null ? mentionerImg.Content : null
                }
            };

        return await query.FirstOrDefaultAsync(cancellationToken);
    }
}
