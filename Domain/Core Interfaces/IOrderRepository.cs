using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task<List<Order>?> GetOrderByUserIdAsync(int userId);
    Task<List<Order>> GetAllAsync();
    Task<Order> AddAsync(Order promotion);
    Task<Order?> UpdateAsync(Order promotion);
    Task<bool> DelAsync(int id);
}
