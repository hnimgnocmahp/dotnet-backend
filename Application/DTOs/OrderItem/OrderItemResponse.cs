namespace Application.DTOs.OrderItem;

public record OrderItemResponse(
    int OrderItemId,
    int OrderId,
    int ProductId,
    int Quantity,
    decimal Price,
    decimal Subtotal
);