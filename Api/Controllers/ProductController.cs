using Api.Models;
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
        var response = await _getProducts.ExecuteAsync();

        return Ok(ApiResponse<string>.SuccessResponse("Get successfully"));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
    {
        var response = await _createProduct.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create product"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("API is working!");
    }

}
