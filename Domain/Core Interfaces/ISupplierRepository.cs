using Domain.Entities;
namespace Domain.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier> AddAsync(Supplier supplier);
    Task<Supplier?> UpdateAsync(Supplier supplier);
    Task<bool> DelAsync(int id);
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetSupplierByIdAsync(int id);
}
