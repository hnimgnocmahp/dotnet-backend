using Api.Models;
using Application.DTOs.Inventory;
using Application.DTOs.Order;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController: ControllerBase
    {
        private readonly CreateInventoryUsecase _createInventory;
        private readonly UpdateInventory

        public InventoryController(
        CreateInventoryUsecase createInventory
        //UpdateOrderUseCase updateOrder,
        //DelOrderUseCase delOrder,
        //GetOrderIdUseCase getOrder,
        //GetOrderByUserIdUseCase getOrderByUser,
        //GetAllOrderUseCase getAll
    )
        {
            _createInventory = createInventory;
            //_updateOrder = updateOrder;
            //_delOrder = delOrder;
            //_getOrder = getOrder;
            //_getOrderByUser = getOrderByUser;
            //_getAll = getAll;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] InventoryRequest request)
        {
            var response = await _createInventory.ExecuteAsync(request);
            if (response == null)
                return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create inventory"));

            return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryRequest request)
        {
            var response = await _update.ExecuteAsync(id, request);
            if (response == null)
                return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

            return Ok(ApiResponse<object>.SuccessResponse(response, "Update successfully"));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var success = await _delOrder.ExecuteAsync(id);
        //    if (!success)
        //        return NotFound(ApiResponse<string>.ErrorResponse("Order not found or cannot delete"));

        //    return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var response = await _getOrder.ExecuteAsync(id);
        //    if (response == null)
        //        return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

        //    return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
        //}

        //[HttpGet("user/{id}")]
        //public async Task<IActionResult> GetByUser(int id)
        //{
        //    var response = await _getOrderByUser.ExecuteAsync(id);
        //    if (response == null)
        //        return NotFound(ApiResponse<string>.ErrorResponse("Order not found"));

        //    return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
        //}

        //[HttpGet()]
        //public async Task<IActionResult> GetAll()
        //{
        //    var response = await _getAll.ExecuteAsync();
        //    if (response == null)
        //        return NotFound(ApiResponse<string>.ErrorResponse("Orders not found"));

        //    return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
        //}

    }
}
