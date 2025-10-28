using Application.DTOs.Supplier;
namespace Application.DTOs.Product;

public record ProductResponse(
    int ProductId,
    CategoryResponse Category,
    SupplierResponse Supplier,
    string ProductName,
    string Barcode,
    decimal Price,
    string Unit,
    DateTime CreatedAt
);
