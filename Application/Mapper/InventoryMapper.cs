using Application.DTOs.Inventory;
using Domain.Entities;

namespace Application.Mappers;
public static class InventoryMapper
{
    public static InventoryResponse ToResponse(this Inventory entity)
        => new(
            entity.InventoryId,
            entity.ProductId,
            entity.Quantity,
            entity.CreatedAt,
            entity.UpdatedAt
        );

    public static Inventory ToEntity(this InventoryRequest entity)
        => new()
        {
            InventoryId = entity.InventoryId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };

    public static IEnumerable<InventoryResponse> ToResponse(this IEnumerable<Inventory> entities)
        => entities.Select(e => e.ToResponse());


}