using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class InventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _context;
    public InventoryRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Inventory>> GetAllAsync()
        => await _context.Inventories.ToListAsync();

    public async Task<Inventory?> GetByIdAsync(int id)
        => await _context.Inventories.FindAsync(id);

    public async Task AddAsync(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
        await _context.SaveChangesAsync();
    }
}
