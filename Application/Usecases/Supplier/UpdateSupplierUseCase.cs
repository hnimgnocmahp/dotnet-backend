using Domain.Interfaces;
using Application.DTOs.Supplier;
using Application.Mappers;  
public class UpdateSupplierUseCase
{
    private readonly ISupplierRepository _repository;

    public UpdateSupplierUseCase(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<SupplierResponse?> ExecuteAsync(int id, SupplierRequest request)
    {
        var existingSupplier = await _repository.GetSupplierByIdAsync(id);
        if (existingSupplier == null)
        {
            return null; // Supplier not found
        }

        // Update the existing supplier's properties
        existingSupplier.Name = request.Name;
        existingSupplier.Phone = request.Phone;
        existingSupplier.Email = request.Email;
        existingSupplier.Address = request.Address;

        var updatedSupplier = await _repository.UpdateAsync(existingSupplier);
        if (updatedSupplier == null)
        {
            return null; // Update failed
        }

        return updatedSupplier.ToResponse();
    }
}