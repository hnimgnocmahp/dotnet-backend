using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderItemRepository
{
    Task<OrderItem?> GetOrderItemByIdAsync(int id);
    Task<List<OrderItem>?> GetOrderItemByOrderIdAsync(int orderId);
    Task<List<OrderItem>> GetAllAsync();
    Task<OrderItem> AddAsync(OrderItem item);
    // Task<OrderItem?> UpdateAsync(OrderItem item);
    // Task<bool> DelAsync(int id);
}

