using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetAllPromotionUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public GetAllPromotionUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<List<PromotionResponse>?> ExecuteAsync()
    {   
        var promotion = await _promotionRepo.GetAllAsync();

        if (promotion == null) return null;
        return promotion.ToResponse();
    } 
}