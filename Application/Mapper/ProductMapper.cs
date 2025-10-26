using Application.DTOs.Product;
using Application.DTOs.Category;
using Application.DTOs.Supplier;
using Domain.Entities;

namespace Application.Mappers;

public static class ProductMapper
{
    public static ProductResponse ToResponse(this Product entity)
        => new(
            entity.ProductId,
            entity.Category == null ? null :  new CategoryResponse(entity.Category.CategoryId, entity.Category.CategoryName),
            entity.Supplier == null ? null :  new SupplierResponse(
                entity.Supplier.SupplierId,
                entity.Supplier.Name,
                entity.Supplier.Phone,
                entity.Supplier.Email,
                entity.Supplier.Address
            ),
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