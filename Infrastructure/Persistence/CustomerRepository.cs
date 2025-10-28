using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) => _context = context;
      public async Task<Customer> AddAsync(Customer customer)
      {
         _context.Customers.Add(customer);
         await _context.SaveChangesAsync();
         return customer;
      }

      public async Task<bool> DeleteAsync(Customer customer)
      {
         _context.Customers.Remove(customer);
         var result = await _context.SaveChangesAsync();

         return result > 0;
      }

      public async Task<PagedResult<Customer>> GetAllPagedAsync(int page, int pageSize)
      {
         var query = _context.Customers.AsNoTracking();

         var totalCount = await query.CountAsync();

         var items = await query
             .OrderBy(c => c.Name) // Luôn OrderBy khi phân trang
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();

         // 4. Trả về đối tượng PagedResult
         return new PagedResult<Customer>(items, totalCount, page, pageSize);
      }

      public async Task<Customer?> GetByEmailAsync(string email)
      {
         return await _context.Customers
             .AsNoTracking()
             .FirstOrDefaultAsync(c => c.Email == email);
      }

      public async Task<Customer?> GetByIdAsync(int id)
      {
         return await _context.Customers.FindAsync(id);
      }

      public async Task<Customer> UpdateAsync(Customer customer)
      {
         _context.Customers.Update(customer);
         await _context.SaveChangesAsync();
         return await _context.Customers.FindAsync(customer.CustomerId) ?? customer;
      }

      public async Task<PagedResult<Customer>?> SearchPagedAsync(string searchTerm, int page, int pageSize)
      {

         if (string.IsNullOrWhiteSpace(searchTerm))
         {
            return new PagedResult<Customer>(new List<Customer>(), 0, page, pageSize);
         }
         var lowerTerm = searchTerm.Trim().ToLower();
         var pattern = $"%{lowerTerm}%";

         var query = _context.Customers
            .Where(c =>
               EF.Functions.Like(c.Name, pattern) ||
               (c.Phone != null && EF.Functions.Like(c.Phone, pattern)) ||
               (c.Email != null && EF.Functions.Like(c.Email, pattern))
            )
            .AsNoTracking();

      var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

         return new PagedResult<Customer>(items, totalCount, page, pageSize);
      }

}
