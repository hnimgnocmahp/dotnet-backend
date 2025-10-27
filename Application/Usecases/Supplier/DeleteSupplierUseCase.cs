using Domain.Interfaces;
namespace Application.UseCases;
public class DeleteSupplierUseCase
{
    private readonly ISupplierRepository _repository;

    public DeleteSupplierUseCase(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        return await _repository.DelAsync(id);
    }
}