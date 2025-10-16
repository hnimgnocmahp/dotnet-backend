using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetAllAsync();
    Task<Inventory?> GetByIdAsync(int id);
    Task AddAsync(Inventory inventory);
    Task UpdateAsync(int id, Inventory inventory);
}
