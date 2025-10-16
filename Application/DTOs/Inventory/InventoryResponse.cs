namespace Application.DTOs.Inventory;

public record InventoryResponse(
    int InventoryId,
    int ProductId,
    int Quantity,
    DateTime CreatedAt,
    DateTime UpdatedAt
);