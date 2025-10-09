namespace Application.DTOs.Order;

public record OrderResponse(
    int OrderId,
    int CustomerId,
    int UserId,
    int? PromoId,
    DateTime OrderDate,
    string Status,
    decimal TotalAmount,
    decimal DiscountAmount
);