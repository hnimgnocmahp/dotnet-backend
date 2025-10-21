using Application.DTOs.OrderItem;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateOrderItemUseCase
{
    private readonly IOrderItemRepository _orderItemRepo;

    public CreateOrderItemUseCase(IOrderItemRepository orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }

    public async Task<OrderItemResponse?> ExecuteAsync(OrderItemRequest request)
    {
        var item = request.ToEntity(); // mapping từ input DTO sang domain
        item.Subtotal = request.Quantity * request.Price;
        await _orderItemRepo.AddAsync(item); // làm việc với entity
        return item.ToResponse(); // mapping domain sang output DTO
    } 
}