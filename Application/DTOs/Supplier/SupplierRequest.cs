// Application/DTOs/Supplier/SupplierRequest.cs
namespace Application.DTOs.Supplier
{   
    public record SupplierRequest
    (
        string Name,
        string Phone,
        string Email,
        string Address
    );
}
