// Application/DTOs/Supplier/SupplierResponse.cs
namespace Application.DTOs.Supplier
{
    public record SupplierResponse
    (
        int SupplierId,
        string Name,
        string Phone,
        string Email,
        string Address
    );
}
