using Application.Interfaces;
using Domain.Interfaces;
using Domain.Entities;
namespace Application.UseCases;
public class DeleteProductUseCase
{
    private readonly IProductRepository _repo;

    public DeleteProductUseCase(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> ExecuteAsync(int productId)
    {
        var product = await _repo.GetByIdAsync(productId);
        if (product == null)
            return false;

        await _repo.DeleteAsync(productId);
        return true;
    }
}