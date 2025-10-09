using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _context;
    public PromotionRepository(AppDbContext context) => _context = context;

    public async Task<Promotion?> GetPromotionByIdAsync(int id)
        => await _context.Promotions.FirstOrDefaultAsync(p => p.PromoId == id);

    public async Task<List<Promotion>?> GetAllAsync()
        => await _context.Promotions.ToListAsync();

    public async Task<List<Promotion>?> GetPromotionsWithMinOrderAmountGreaterThanAsync(decimal minOrderAmount)
        => await _context.Promotions.Where(o => o.MinOrderAmount >= minOrderAmount && o.EndDate >= DateTime.Now && o.Status.Equals("active")).ToListAsync();

    public async Task<Promotion> AddAsync(Promotion promotion)
    {
        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<Promotion?> UpdateAsync(Promotion promotion)
    {
        _context.Promotions.Update(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }

    public async Task<bool> DelAsync(int id)
    {
        var existing = await _context.Promotions.FindAsync(id);
        if (existing == null) return false;
        _context.Promotions.Remove(existing);
        await _context.SaveChangesAsync();
        return true;   
    }

}
