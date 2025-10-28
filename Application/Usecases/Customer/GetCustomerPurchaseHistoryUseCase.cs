using Application.DTOs.Order;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic; // Dùng cho KeyNotFoundException
using System.Linq; // Dùng cho .Select (LINQ)
using System.Threading.Tasks;

namespace Application.Usecases.Customer;

public class GetCustomerPurchaseHistoryUseCase(
    IOrderRepository orderRepository,
    ICustomerRepository customerRepository) // Inject thêm ICustomerRepository
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<IEnumerable<OrderResponse>> ExecuteAsync(int customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
        {
            throw new KeyNotFoundException("Không tìm thấy khách hàng.");
        }

        var orders = await _orderRepository.GetByCustomerIdWithDetailsAsync(customerId);

        var historyDtos = orders.Select(order => new OrderResponse(
            order.OrderId,
            order.CustomerId,
            order.UserId,
            order.PromoId,
            order.OrderDate, 
            order.Status,
            order.TotalAmount,
            order.DiscountAmount
         ));

        return historyDtos;
    }
}