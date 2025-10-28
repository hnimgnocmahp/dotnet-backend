// Application/Mappers/SupplierMapper.cs
using Application.DTOs.Supplier;
using Domain.Entities;

namespace Application.Mappers
{
    public static class SupplierMapper
    {
        public static SupplierResponse ToResponse(this Supplier entity)
            => new(
                entity.SupplierId,
                entity.Name,
                entity.Phone,
                entity.Email,
                entity.Address
            );

        public static Supplier ToEntity(this SupplierRequest dto)
            => new()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address
            };

        public static IEnumerable<SupplierResponse> ToResponse(this IEnumerable<Supplier> entities)
            => entities.Select(e => e.ToResponse());
    }
}
