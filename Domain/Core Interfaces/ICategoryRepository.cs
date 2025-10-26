
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);
    Task<Category?> UpdateAsync(Category category);
    Task<bool> DelAsync(int id);
}
