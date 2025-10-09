using Api.Models;
using Application.DTOs.Promotion;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]public class PromotionController : Controller
{
    private readonly CreatePromotionUseCase _createPromotion;
    private readonly UpdatePromotionUseCase _updatePromotion;
    private readonly DelPromotionUseCase _delPromotion;
    private readonly GetPromotionByIdUseCase _getPromotion;
    private readonly GetAllPromotionUseCase _getAll;
    private readonly GetPromotionsWithMinOrderAmountGreaterThanUseCase _getPromotionsWithMinOrderAmountGreaterThan;

    public PromotionController(
        CreatePromotionUseCase createPromotion,
        UpdatePromotionUseCase updatePromotion,
        DelPromotionUseCase delPromotion,
        GetPromotionByIdUseCase getPromotion,
        GetAllPromotionUseCase getAll,
        GetPromotionsWithMinOrderAmountGreaterThanUseCase getPromotionsWithMinOrderAmountGreaterThan
    )
    {
        _createPromotion = createPromotion;
        _updatePromotion = updatePromotion;
        _delPromotion = delPromotion;
        _getPromotion = getPromotion;
        _getAll = getAll;
        _getPromotionsWithMinOrderAmountGreaterThan = getPromotionsWithMinOrderAmountGreaterThan;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] PromotionRequest request)
    {
        var response = await _createPromotion.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create promotion"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PromotionRequest request)
    {
        var response = await _updatePromotion.ExecuteAsync(id, request);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Promotion not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Update successfully"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _delPromotion.ExecuteAsync(id);
        if (!success)
            return NotFound(ApiResponse<string>.ErrorResponse("Promotion not found or cannot delete"));

        return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _getPromotion.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Promotion not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _getAll.ExecuteAsync();
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Promotion not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet("min-order/{minOrderAmount}")]
    public async Task<IActionResult> GetPromotionsWithMinOrderAmountGreaterThanAsync(decimal minOrderAmount)
    {
        var response = await _getPromotionsWithMinOrderAmountGreaterThan.ExecuteAsync(minOrderAmount);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Promotion not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }
    
}