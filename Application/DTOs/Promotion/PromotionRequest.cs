namespace Application.DTOs.Promotion;

public record PromotionRequest(
    string PromoCode,
    string Description,
    string DiscountType,
    decimal DiscountValue,
    DateTime StartDate,
    DateTime EndDate,
    decimal MinOrderAmount,
    int UsageLimit,
    string Status
);