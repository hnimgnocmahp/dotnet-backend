using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<Order?> GetOrderByIdAsync(int id)
        => await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);

    public async Task<List<Order>?> GetOrderByUserIdAsync(int UserId)
        => await _context.Orders.Where(o => o.UserId == UserId).ToListAsync();

    public async Task<List<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<bool> DelAsync(int id)
    {
        var existing = await _context.Orders.FindAsync(id);
        if (existing == null) return false;
        _context.Orders.Remove(existing);
        await _context.SaveChangesAsync();
        return true;   
    }

}
