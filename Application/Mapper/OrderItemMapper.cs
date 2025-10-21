using Application.DTOs.OrderItem;
using Domain.Entities;

namespace Application.Mappers;


public static class OrderItemMapper
{
    public static OrderItemResponse ToResponse(this OrderItem entity)
        => new(
            entity.OrderItemId,
            entity.OrderId,
            entity.ProductId,
            entity.Quantity,
            entity.Price,
            entity.Subtotal
        );

    public static List<OrderItemResponse> ToResponse(this IEnumerable<OrderItem> entities)
        => entities.Select(o => o.ToResponse()).ToList();

    public static OrderItem ToEntity(this OrderItemRequest request)
        => new()
        {
            OrderItemId = request.OrderItemId,
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Price,
        };

}
