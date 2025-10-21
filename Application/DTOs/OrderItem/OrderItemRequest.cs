namespace Application.DTOs.OrderItem;

public record OrderItemRequest
(
    int OrderItemId,
    int OrderId,
    int ProductId,
    int Quantity,
    decimal Price
);