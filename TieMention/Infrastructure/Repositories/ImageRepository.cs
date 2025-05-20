using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Infrastructure.Data;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Image?> GetByIdAsync(Guid id)
    {
        return await _context.Image.FindAsync(id);
    }

    public async Task<IEnumerable<Image>> GetAllAsync()
    {
        return await _context.Image.ToListAsync();
    }

    public async Task AddAsync(Image image)
    {
        await _context.Image.AddAsync(image);
    }

    public async Task UpdateAsync(Image image)
    {
        _context.Image.Update(image);
    }

    public async Task DeleteAsync(Image image)
    {
        _context.Image.Remove(image);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}