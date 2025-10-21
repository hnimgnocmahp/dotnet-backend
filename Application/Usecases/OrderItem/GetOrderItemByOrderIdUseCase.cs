using Application.DTOs.OrderItem;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetOrderItemByOrderIdUseCase
{
    private readonly IOrderItemRepository _orderItemRepo;

    public GetOrderItemByOrderIdUseCase(IOrderItemRepository orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }

    public async Task<List<OrderItemResponse>?> ExecuteAsync(int orderId)
    {   
        var item = await _orderItemRepo.GetOrderItemByOrderIdAsync(orderId);

        if (item == null) return null;

        return item.ToResponse();
    } 
}