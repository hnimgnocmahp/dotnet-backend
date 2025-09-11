using Application.DTOs.Product;
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

    public async Task<Product> ExecuteAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.name,
            Price = request.price
        };

        await _repo.AddAsync(product);

        return product;
    }
}