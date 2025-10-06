using Application.DTOs.Product;
using Domain.Entities;

namespace Application.Mappers;

public static class ProductMapper
{
    public static ProductResponse ToResponse(this Product entity)
        => new(
            entity.ProductId,
            entity.CategoryId,
            entity.SupplierId,
            entity.ProductName,
            entity.Barcode,
            entity.Price,
            entity.Unit,
            entity.CreatedAt
        );

    public static Product ToEntity(this ProductRequest entity)
        => new()
        {
            CategoryId = entity.CategoryId,
            SupplierId = entity.SupplierId,
            ProductName = entity.ProductName,
            Barcode = entity.Barcode,
            Price = entity.Price,
            Unit = entity.Unit,
        };
        
    public static IEnumerable<ProductResponse> ToResponse(this IEnumerable<Product> entities)
        => entities.Select(e => e.ToResponse());



 
}