// Application/UseCases/CreateSupplierUseCase.cs
using Application.DTOs.Supplier;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.UseCases
{
    public class CreateSupplierUseCase
    {
        private readonly ISupplierRepository _repository;

        public CreateSupplierUseCase(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupplierResponse> ExecuteAsync(SupplierRequest request)
        {
            var entity = request.ToEntity();
            await _repository.AddAsync(entity);
            return entity.ToResponse();
        }
    }
}
