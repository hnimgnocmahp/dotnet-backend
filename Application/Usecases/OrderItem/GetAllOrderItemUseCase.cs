using Application.DTOs.OrderItem;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetAllOrderItemUseCase
{
    private readonly IOrderItemRepository _orderItemRepo;

    public GetAllOrderItemUseCase(IOrderItemRepository orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }

    public async Task<List<OrderItemResponse>?> ExecuteAsync()
    {   
        var orderItem = await _orderItemRepo.GetAllAsync();

        if (orderItem == null) return null;

        return orderItem.ToResponse();
    } 
}