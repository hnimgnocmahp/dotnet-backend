using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class UpdatePromotionUseCase
{
    private readonly IPromotionRepository _promotionRepo;

    public UpdatePromotionUseCase(IPromotionRepository promotionRepo)
    {
        _promotionRepo = promotionRepo;
    }

    public async Task<PromotionResponse?> ExecuteAsync(int id, PromotionRequest request)
    {

        var promotion = await _promotionRepo.GetPromotionByIdAsync(id);

        if (promotion == null) return null;

        promotion.Description = request.Description;
        promotion.DiscountType = request.DiscountType;
        promotion.DiscountValue = request.DiscountValue;
        promotion.StartDate = request.StartDate;
        promotion.EndDate = request.EndDate;
        promotion.MinOrderAmount = request.MinOrderAmount;
        promotion.UsageLimit = request.UsageLimit;
        promotion.Status = request.Status;

        await _promotionRepo.UpdateAsync(promotion);

        return promotion.ToResponse();

    }

}