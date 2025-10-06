namespace Application.Mappers;

using Application.DTOs.Promotion;
using Domain.Entities;

public static class PromotionMapper
{
    public static PromotionResponse ToResponse(this Promotion entity)
        => new(
            entity.PromoId,
            entity.PromoCode,
            entity.Description ?? string.Empty,
            entity.DiscountType,
            entity.DiscountValue,
            entity.StartDate,
            entity.EndDate,
            entity.MinOrderAmount,
            entity.UsageLimit,
            entity.Status
        );

    public static Promotion ToEntity(this PromotionRequest request)
        => new()
        {
            PromoCode = request.PromoCode,
            Description = request.Description,
            DiscountType = request.DiscountType,
            DiscountValue = request.DiscountValue,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MinOrderAmount = request.MinOrderAmount,
            UsageLimit = request.UsageLimit,
            Status = request.Status
        };
}
