
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPromotionRepository
{
    Task<Promotion?> GetPromotionByIdAsync(int id);
    Task<List<Promotion>?> GetAllAsync();
    Task<List<Promotion>?> GetPromotionsWithMinOrderAmountGreaterThanAsync(decimal minOrderAmount);
    Task<Promotion> AddAsync(Promotion promotion);
    Task<Promotion?> UpdateAsync(Promotion promotion);
    Task<bool> DelAsync(int id);
}
