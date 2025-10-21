using Application.DTOs.Order;
using Domain.Entities;

namespace Application.Mappers;


public static class OrderMapper
{
    public static OrderResponse ToResponse(this Order entity)
        => new(
            entity.OrderId,
            entity.CustomerId,
            entity.UserId,
            entity.PromoId,
            entity.OrderDate,
            entity.Status,
            entity.TotalAmount,
            entity.DiscountAmount
        );

    public static List<OrderResponse> ToResponse(this IEnumerable<Order> entities)
        => entities.Select(o => o.ToResponse()).ToList();

    public static Order ToEntity(this OrderRequest request)
        => new()
        {
            CustomerId = request.CustomerId,
            UserId = request.UserId,
            PromoId = request.PromoId,
            TotalAmount = request.TotalAmount,
            DiscountAmount = request.DiscountAmount,
            Status = request.Status
        };

}
