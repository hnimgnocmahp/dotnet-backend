using Api.Models;
using Application.DTOs.Product;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class ProductController : ControllerBase
{
    private readonly GetProductsUseCase _getProducts;
    private readonly CreateProductUseCase _createProduct;
    private readonly DeleteProductUseCase _deleteProduct;
    private readonly UpdateProductUseCase _updateProduct;

    public ProductController(GetProductsUseCase getProducts, CreateProductUseCase createProduct, DeleteProductUseCase deleteProduct, UpdateProductUseCase updateProduct)
    {
        _getProducts = getProducts;
        _createProduct = createProduct;
        _deleteProduct = deleteProduct;
        _updateProduct = updateProduct;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getProducts.ExecuteAsync();

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
    {
        var response = await _createProduct.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create product"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id, [FromServices] DeleteProductUseCase deleteProduct)
    {
        var result = await deleteProduct.ExecuteAsync(id);
        if (!result)
            return NotFound(ApiResponse<string>.ErrorResponse("Product not found"));
        return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductRequest productRequest)
    {
        var response = await _updateProduct.ExecuteAsync(id, productRequest);
        if (response == null)
        {
            return NotFound(ApiResponse<string>.ErrorResponse("Update fail"));
        }
        return Ok(ApiResponse<object>.SuccessResponse(response,"Update success"));
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("API is working!");
    }

}
