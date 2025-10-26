using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;
    public SupplierRepository(AppDbContext context) => _context = context;

    public async Task<Supplier?> GetSupplierByIdAsync(int id)
        => await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == id);
    public async Task<List<Supplier>> GetAllAsync()
        => await _context.Suppliers.ToListAsync();
    public async Task<Supplier> AddAsync(Supplier supplier)
    {
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }
    public async Task<Supplier?> UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }
    public async Task<bool> DelAsync(int id){
        var existing = await _context.Suppliers.FindAsync(id);
        if (existing == null) return false;
        _context.Suppliers.Remove(existing);
        await _context.SaveChangesAsync();
        return true;   
    }

}
