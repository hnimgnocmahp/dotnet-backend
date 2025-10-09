using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepo;

    public CreateOrderUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<OrderResponse?> ExecuteAsync(OrderRequest request)
    {
        var order = request.ToEntity(); // mapping từ input DTO sang domain
        await _orderRepo.AddAsync(order); // làm việc với entity
        return order.ToResponse(); // mapping domain sang output DTO
    } 
}