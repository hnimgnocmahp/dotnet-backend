using Api.Models;
using Application.DTOs.Customer;
using Application.Usecases.Customer;
using Application.UseCases;
using Application.UseCases.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(
        CreateCustomerUseCase createCustomerUseCase,
        UpdateCustomerUseCase updateCustomerUseCase,
        DeleteCustomerUseCase deleteCustomerUseCase,
        GetCustomerByIdUseCase getCustomerByIdUseCase,
        SearchCustomersUseCase searchCustomersUseCase,
        GetCustomerSegmentUseCase getCustomerSegmentUseCase,
        GetCustomerPurchaseHistoryUseCase getCustomerPurchaseHistoryUseCase,
        GetAllCustomersUseCase getAllCustomersUseCase) : ControllerBase
    {
         private readonly CreateCustomerUseCase _createCustomerUseCase = createCustomerUseCase;
         private readonly UpdateCustomerUseCase _updateCustomerUseCase = updateCustomerUseCase;
         private readonly DeleteCustomerUseCase _deleteCustomerUseCase = deleteCustomerUseCase;
         private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase = getCustomerByIdUseCase;
         private readonly GetAllCustomersUseCase _getAllCustomersUseCase = getAllCustomersUseCase;
         private readonly SearchCustomersUseCase _searchCustomersUseCase = searchCustomersUseCase;
         private readonly GetCustomerSegmentUseCase _getCustomerSegmentUseCase = getCustomerSegmentUseCase;
         private readonly GetCustomerPurchaseHistoryUseCase _getCustomerPurchaseHistoryUseCase = getCustomerPurchaseHistoryUseCase;


      //GET: api/customers?page=2&pageSize=5
      [HttpGet]
      public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
      {
         // 1. Gọi UseCase với tham số phân trang
         var pagedResult = await _getAllCustomersUseCase.ExecuteAsync(page, pageSize);

         // 2. Kiểm tra kết quả
         if (pagedResult == null || pagedResult.TotalCount == 0)
            return NotFound(ApiResponse<string>.ErrorResponse("Customers not found"));

         // 3. Trả về kết quả đã được phân trang
         return Ok(ApiResponse<object>.SuccessResponse(pagedResult, "Get successfully"));
      }

      // GET: api/Customers/5
      [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _getCustomerByIdUseCase.ExecuteAsync(id);
            if (response == null)
               return NotFound(ApiResponse<string>.ErrorResponse("Customer not found"));

            return Ok(ApiResponse<object>.SuccessResponse(response, "Get successfully"));
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] UpdateCustomerRequest req)
        {
            var response = await _updateCustomerUseCase.ExecuteAsync(id, req);
            if (response == null)
               return NotFound(ApiResponse<string>.ErrorResponse("Customer not found"));

            return Ok(ApiResponse<object>.SuccessResponse(response, "Update successfully"));
      }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerRequest req)
        {
            var response = await _createCustomerUseCase.ExecuteAsync(req);
            if (response == null)
               return BadRequest(ApiResponse<string>.ErrorResponse("Cannot create customer"));

            return Ok(ApiResponse<object>.SuccessResponse(response, "Create successfully"));
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _deleteCustomerUseCase.ExecuteAsync(id);
            if (!success)
               return NotFound(ApiResponse<string>.ErrorResponse("Customer not found or cannot delete"));

            return Ok(ApiResponse<string>.SuccessResponse("Delete successfully"));
        }

      // GET: api/customers/search?term=nguyen&page=2&pageSize=5
      [HttpGet("search")]
      public async Task<IActionResult> SearchCustomers([FromQuery] string? term,
                                                        [FromQuery] int page = 1,
                                                        [FromQuery] int pageSize = 10)
      {
         // (Use Case đã kiểm tra term rỗng, nhưng kiểm tra ở đây cũng tốt)
         if (string.IsNullOrWhiteSpace(term))
         {
            return BadRequest(ApiResponse<string>.ErrorResponse("The search keyword cannot be empty"));
         }

         // 1. Gọi UseCase với tham số phân trang VÀ term
         var pagedResult = await _searchCustomersUseCase.ExecuteAsync(term, page, pageSize);

         // 2. Kiểm tra kết quả
         if (pagedResult == null || pagedResult.TotalCount == 0)
         {
            return NotFound(ApiResponse<string>.ErrorResponse("No customers found"));
         }

         // 3. Trả về kết quả đã được phân trang
         return Ok(ApiResponse<object>.SuccessResponse(pagedResult, "Search successfully"));
      }

      // GET: api/customers/5/segment
        [HttpGet("{id:int}/segment")]
        public async Task<IActionResult> GetCustomerSegment(int id)
        {
            var segmentDto = await _getCustomerSegmentUseCase.ExecuteAsync(id);
            if (segmentDto == null)
               return NotFound(ApiResponse<string>.ErrorResponse("Customer segment not found"));

            return Ok(ApiResponse<object>.SuccessResponse(segmentDto, "Get segment successfully"));
            
        }

         // GET: api/customers/1/history
         [HttpGet("{id:int}/history")]
         public async Task<IActionResult> GetPurchaseHistory(int id)
         {
            try
            {
               var history = await _getCustomerPurchaseHistoryUseCase.ExecuteAsync(id);
               // Trả về 200 OK (ngay cả khi danh sách rỗng)
               return Ok(ApiResponse<object>.SuccessResponse(history, "Get history successfully"));
            }
            catch (KeyNotFoundException ex) // Bắt lỗi 404 nếu không tìm thấy Customer
            {
               return NotFound(ApiResponse<string>.ErrorResponse(ex.Message));
            }
            catch (Exception ex) // Bắt các lỗi chung khác
            {
               // Trả về 500 Internal Server Error
               return StatusCode(500, ApiResponse<string>.ErrorResponse($"An error occurred: {ex.Message}"));
            }
         }

   }
}
