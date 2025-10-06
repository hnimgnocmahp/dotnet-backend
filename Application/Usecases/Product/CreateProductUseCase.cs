using Application.DTOs.Product;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _repo;

    public CreateProductUseCase(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<ProductResponse> ExecuteAsync(ProductRequest request)
    {
        var product = request.ToEntity();
        await _repo.AddAsync(product);
        return product.ToResponse();
    }
}