using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetAllOrderUseCase
{
    private readonly IOrderRepository _orderRepo;

    public GetAllOrderUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<List<OrderResponse>?> ExecuteAsync()
    {   
        var order = await _orderRepo.GetAllAsync();

        if (order == null) return null;

        return order.ToResponse();
    } 
}