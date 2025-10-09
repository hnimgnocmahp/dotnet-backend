using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetPromotionsWithMinOrderAmountGreaterThanUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public GetPromotionsWithMinOrderAmountGreaterThanUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<List<PromotionResponse>?> ExecuteAsync(decimal minOrderAmount)
    {   
        var promotion = await _promotionRepo.GetPromotionsWithMinOrderAmountGreaterThanAsync(minOrderAmount);

        if (promotion == null) return null;
        return promotion.ToResponse();
    } 
}