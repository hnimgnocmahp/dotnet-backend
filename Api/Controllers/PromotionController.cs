using Api.Models;
using Application.DTOs.Promotion;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]public class PromotionController : Controller
{
    private readonly AddPromotionUseCase _addPromotion;
    private readonly UpdatePromotionUseCase _updatePromotion;
    private readonly DelPromotionUseCase _delPromotion;
    private readonly GetPromotionByIdUseCase _getPromotion;

    public PromotionController(AddPromotionUseCase addPromotion, UpdatePromotionUseCase updatePromotion, DelPromotionUseCase delPromotion, GetPromotionByIdUseCase getPromotion)
    {
        _addPromotion = addPromotion;
        _updatePromotion = updatePromotion;
        _delPromotion = delPromotion;
        _getPromotion = getPromotion;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] PromotionRequest request)
    {
        var response = await _addPromotion.ExecuteAsync(request);
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
}