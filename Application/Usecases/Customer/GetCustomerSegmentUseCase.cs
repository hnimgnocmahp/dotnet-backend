using Application.DTOs.Customer;
using Domain.Interfaces;
namespace Application.UseCases.Customer;

public class GetCustomerSegmentUseCase(
    ICustomerRepository customerRepository,
    IOrderRepository orderRepository)
{
   private readonly ICustomerRepository _customerRepository = customerRepository;
   private readonly IOrderRepository _orderRepository = orderRepository;

   private const decimal VIP_THRESHOLD = 50_000_000m; // 50 triệu
   private const decimal LOYAL_THRESHOLD = 5_000_000m; // 5 triệu
                                                       // ----------------------------------------

   public async Task<CustomerSegmentDto?> ExecuteAsync(int customerId)
   {
      // 1. Lấy thông tin khách hàng (để lấy tên + kiểm tra tồn tại)
      var customer = await _customerRepository.GetByIdAsync(customerId);
      if (customer == null)
      {
         throw new KeyNotFoundException("Not found customer");
      }

      // 2. Lấy tổng chi tiêu từ OrderRepository
      var totalSpending = await _orderRepository.GetTotalSpendingByCustomerIdAsync(customerId);

      // 3. Thực thi logic phân loại
      string segment;
      if (totalSpending >= VIP_THRESHOLD)
      {
         segment = "VIP";
      }
      else if (totalSpending >= LOYAL_THRESHOLD)
      {
         segment = "LOYAL";
      }
      else
      {
         segment = "NEW";
      }

      // 4. Trả về DTO
      return new CustomerSegmentDto(
          customer.CustomerId,
          customer.Name,
          segment,
          totalSpending
      );
   }
}