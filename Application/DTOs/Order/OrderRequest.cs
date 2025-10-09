namespace Application.DTOs.Order;

public record OrderRequest(
    int CustomerId,
    int UserId,
    int PromoId,
    decimal TotalAmount,
    decimal DiscountAmount
);