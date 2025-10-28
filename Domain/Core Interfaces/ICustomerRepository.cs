
using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
   Task<Customer?> GetByIdAsync(int id);
   Task<PagedResult<Customer>> GetAllPagedAsync(int page, int pageSize);
   Task<Customer?> GetByEmailAsync(string email); // Check trùng lặp
   Task<Customer> AddAsync(Customer customer);
   Task<Customer> UpdateAsync(Customer customer);
   Task<bool> DeleteAsync(Customer customer);
   Task<PagedResult<Customer>> SearchPagedAsync(string searchTerm, int page, int pageSize);
}
