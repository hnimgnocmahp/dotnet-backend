using Domain.Interfaces;

namespace Application.UseCases;

public class DelPromotionUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public DelPromotionUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<bool> ExecuteAsync(int id)
    { 
        await _promotionRepo.DelAsync(id);
        return true;
    } 
}