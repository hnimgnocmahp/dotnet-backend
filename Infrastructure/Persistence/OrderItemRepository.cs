using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;
    public OrderItemRepository(AppDbContext context) => _context = context;

    public async Task<OrderItem?> GetOrderItemByIdAsync(int id)
        => await _context.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == id);

    public async Task<List<OrderItem>?> GetOrderItemByOrderIdAsync(int orderId)
        => await _context.OrderItems.Where(o => o.OrderId == orderId).ToListAsync();

    public async Task<List<OrderItem>> GetAllAsync()
        => await _context.OrderItems.ToListAsync();

    public async Task<OrderItem> AddAsync(OrderItem item)
    {
        _context.OrderItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    // public async Task<OrderItem?> UpdateAsync(OrderItem item)
    // {
    //     _context.OrderItems.Update(item);
    //     await _context.SaveChangesAsync();
    //     return item;
    // }

    // public async Task<bool> DelAsync(int id)
    // {
    //     var existing = await _context.OrderItems.FindAsync(id);
    //     if (existing == null) return false;
    //     _context.OrderItems.Remove(existing);
    //     await _context.SaveChangesAsync();
    //     return true;
    // }

}
