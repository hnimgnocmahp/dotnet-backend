// Application/UseCases/CreateSupplierUseCase.cs
using Application.DTOs.Supplier;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.UseCases
{
    public class GetAllSupplierUseCase
    {
        private readonly ISupplierRepository _repository;

        public GetAllSupplierUseCase(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SupplierResponse>?> ExecuteAsync()
        {   
            var supplier = await _repository.GetAllAsync();
            if (supplier == null) return null;
            return supplier.ToResponse().ToList();;
        } 
    }
}
