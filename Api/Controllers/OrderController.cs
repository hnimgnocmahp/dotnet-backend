using Api.Models;
using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]public class OrderController : Controller
{
    private readonly CreateOrderUseCase _createOrder;
    private readonly UpdateOrderUseCase _updateOrder;
    private readonly DelOrderUseCase _delOrder;
    private readonly GetOrderIdUseCase _getOrder;
    private readonly GetOrderByUserIdUseCase _getOrderByUser;
    private readonly GetAllOrderUseCase _getAll;

    public OrderController(
        CreateOrderUseCase createOrder,
        UpdateOrderUseCase updateOrder,
        DelOrderUseCase delOrder,
        GetOrderIdUseCase getOrder,
        GetOrderByUserIdUseCase getOrderByUser,
        GetAllOrderUseCase getAll
    )
    {
        _createOrder = createOrder;
        _updateOrder = updateOrder;
        _delOrder = delOrder;
        _getOrder = getOrder;
        _getOrderByUser = getOrderByUser;
        _getAll = getAll;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] OrderRequest request)
    {
        var response = await _createOrder.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create order"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderRequest request)
    {
        var response = await _updateOrder.ExecuteAsync(id, request);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Update successfully"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _delOrder.ExecuteAsync(id);
        if (!success)
            return NotFound(ApiResponse<string>.ErrorResponse("Order not found or cannot delete"));

        return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _getOrder.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUser(int id)
    {
        var response = await _getOrderByUser.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAll.ExecuteAsync();
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("Orders not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }
}