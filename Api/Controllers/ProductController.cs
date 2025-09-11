using Application.DTOs.Product;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly GetProductsUseCase _getProducts;
    private readonly CreateProductUseCase _createProduct;

    public ProductController(GetProductsUseCase getProducts, CreateProductUseCase createProduct)
    {
        _getProducts = getProducts;
        _createProduct = createProduct;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getProducts.ExecuteAsync();
        return Ok(products);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var product = await _createProduct.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("API is working!");
    }





    
}
