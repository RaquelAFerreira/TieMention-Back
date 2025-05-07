using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;

namespace TieMention.Infrastructure.Repositories;

public class MentionRepository : IMentionRepository
{
    private readonly AppDbContext _context;

    public MentionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Mention?> GetByIdAsync(int id)
    {
        return await _context.Mentions.FindAsync(id);
    }

    public async Task<IEnumerable<Mention>> GetAllAsync()
    {
        return await _context.Mentions.ToListAsync();
    }

    public async Task AddAsync(Mention mention)
    {
        await _context.Mentions.AddAsync(mention);
    }

    public async Task UpdateAsync(Mention mention)
    {
        _context.Mentions.Update(mention);
    }

    public async Task DeleteAsync(Mention mention)
    {
        _context.Mentions.Remove(mention);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}