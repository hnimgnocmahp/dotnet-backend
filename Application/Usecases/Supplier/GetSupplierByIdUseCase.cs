using Application.DTOs.Supplier;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetSupplierByIdUseCase
{
    private readonly ISupplierRepository _repository;

    public GetSupplierByIdUseCase(ISupplierRepository repository)
    {
       _repository = repository;
    }

    public async Task<SupplierResponse?> ExecuteAsync(int id)
    {   
        var supplier = await _repository.GetSupplierByIdAsync(id);

        if (supplier == null) return null;
        return supplier.ToResponse();
    } 
}