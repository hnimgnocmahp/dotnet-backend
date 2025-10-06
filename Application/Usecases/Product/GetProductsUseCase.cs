using Application;
using Application.DTOs.Product;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetProductsUseCase
{
    private readonly IProductRepository _repo;

    public GetProductsUseCase(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProductResponse>> ExecuteAsync()
    {
        var products = await _repo.GetAllAsync();
        return products.ToResponse();
    }
}
