namespace Application.DTOs.Inventory;

public record InventoryRequest(
    int InventoryId,
    int ProductId,
    int Quantity,
    DateTime CreatedAt,
    DateTime UpdatedAt
);