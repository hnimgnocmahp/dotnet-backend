using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetOrderByUserIdUseCase
{
    private readonly IOrderRepository _orderRepo;

    public GetOrderByUserIdUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<List<OrderResponse>?> ExecuteAsync(int userId)
    {   
        var order = await _orderRepo.GetOrderByUserIdAsync(userId);

        if (order == null) return null;

        return order.ToResponse();
    } 
}