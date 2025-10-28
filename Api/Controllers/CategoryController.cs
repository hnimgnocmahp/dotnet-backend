using Application.Usecases.Category;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Application.DTOs.Category;
[ApiController]
[Route("api/[controller]")]

public class CategoryController : Controller
{
    private readonly CreateCategoryUseCase _createCategory;
    private readonly GetCategoryByIdUseCase _getCategory;
    private readonly GetAllCategoryUseCase _getAll;

    public CategoryController(
        CreateCategoryUseCase createCategory,

        GetCategoryByIdUseCase getCategory,
        GetAllCategoryUseCase getAll
    )
    {
        _createCategory = createCategory;
        _getCategory = getCategory;
        _getAll = getAll;
    }
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAll.ExecuteAsync();
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Categories not found"));
        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _getCategory.ExecuteAsync(id);
        if (res == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Category not found"));
        return Ok(ApiResponse<object>.SuccessResponse(res, "Get successfully"));
    }
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CategoryRequest request)
    {
        var response = await _createCategory.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create category"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }
}