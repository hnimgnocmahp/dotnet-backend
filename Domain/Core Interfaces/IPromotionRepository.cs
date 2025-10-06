
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPromotionRepository
{
    Task<Promotion?> GetPromotionByIdAsync(int id);
    Task<Promotion> AddAsync(Promotion promotion);
    Task<Promotion?> UpdateAsync(Promotion promotion);
    Task<bool> DelAsync(int id);
}
