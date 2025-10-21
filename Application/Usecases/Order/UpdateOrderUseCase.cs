using Application.DTOs.Order;
using Application.DTOs.Promotion;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class UpdateOrderUseCase
{
    private readonly IOrderRepository _orderRepo;

    public UpdateOrderUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<OrderResponse?> ExecuteAsync(int id, OrderRequest request)
    {

        var order = await _orderRepo.GetOrderByIdAsync(id);

        if (order == null) return null;

        order.Status = request.Status;

        await _orderRepo.UpdateAsync(order);

        return order.ToResponse();

    }

}