namespace Application.DTOs.Product;

public record ProductRequest(
    int CategoryId,
    int SupplierId,
    string ProductName,
    string Barcode,
    decimal Price,
    string Unit
);