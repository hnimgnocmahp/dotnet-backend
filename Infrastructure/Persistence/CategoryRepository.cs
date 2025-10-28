using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context) => _context = context;

    public async Task<Category?> GetCategoryByIdAsync(int id)
        => await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
    public async Task<List<Category>> GetAllAsync()
        => await _context.Categories.ToListAsync();
    public async Task<Category> AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<Category?> UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<bool> DelAsync(int id)
    {
        var existing = await _context.Categories.FindAsync(id);
        if (existing == null) return false;
        _context.Categories.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }

}
