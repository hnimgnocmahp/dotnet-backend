using Application.DTOs.OrderItem;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetOrderItemByIdUseCase
{
    private readonly IOrderItemRepository _orderItemRepo;

    public GetOrderItemByIdUseCase(IOrderItemRepository orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }

    public async Task<OrderItemResponse?> ExecuteAsync(int id)
    {   
        var order = await _orderItemRepo.GetOrderItemByIdAsync(id);
        if (order == null) return null;
        return order.ToResponse();
    } 
}