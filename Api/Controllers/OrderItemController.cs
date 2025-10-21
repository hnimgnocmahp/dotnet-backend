using Api.Models;
using Application.DTOs.OrderItem;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : Controller
{
    private readonly CreateOrderItemUseCase _createOrderItem;
    private readonly GetOrderItemByIdUseCase _getOrderItem;
    private readonly GetOrderItemByIdUseCase _getOrderItemByOrder;
    private readonly GetAllOrderItemUseCase _getAll;

    public OrderItemController(
        CreateOrderItemUseCase createOrderItem,
        GetOrderItemByIdUseCase getOrderItem,
        GetOrderItemByIdUseCase getOrderItemByOrder,
        GetAllOrderItemUseCase getAll
    )
    {
        _createOrderItem = createOrderItem;
        _getOrderItem = getOrderItem;
        _getOrderItemByOrder = getOrderItemByOrder;
        _getAll = getAll;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] OrderItemRequest request)
    {
        var response = await _createOrderItem.ExecuteAsync(request);
        if (response == null)
            return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create orderItemm"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _getOrderItem.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("OrderItem not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet("order/{id}")]
    public async Task<IActionResult> GetByOrder(int id)
    {
        var response = await _getOrderItemByOrder.ExecuteAsync(id);
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("OrderItem not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAll.ExecuteAsync();
        if (response == null)
            return NotFound(ApiResponse<string>.ErrorResponse("OrderItems not found"));

        return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
    }
}