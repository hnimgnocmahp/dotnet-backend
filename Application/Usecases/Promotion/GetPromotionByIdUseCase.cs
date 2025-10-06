using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetPromotionByIdUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public GetPromotionByIdUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<PromotionResponse?> ExecuteAsync(int id)
    {   
        var promotion = await _promotionRepo.GetPromotionByIdAsync(id);

        if (promotion == null) return null;
        return promotion.ToResponse();
    } 
}