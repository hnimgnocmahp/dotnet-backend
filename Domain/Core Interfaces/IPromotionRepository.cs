
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPromotionRepository
{
    Task<User?> GetPromotionByIdAsync(int id);
    Task<User> AddAsync(Promotion promotion);
    Task<User> UpdateAsyncs(int id);
    Task DelAsyncs(int id);
}
