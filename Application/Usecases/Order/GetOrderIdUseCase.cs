using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetOrderIdUseCase
{
    private readonly IOrderRepository _orderRepo;

    public GetOrderIdUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<OrderResponse?> ExecuteAsync(int id)
    {   
        var order = await _orderRepo.GetOrderByIdAsync(id);

        if (order == null) return null;
        return order.ToResponse();
    } 
}