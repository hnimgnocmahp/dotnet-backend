using Domain.Interfaces;

namespace Application.UseCases;

public class DelOrderUseCase
{
    private readonly IOrderRepository _orderRepo;

    public DelOrderUseCase(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<bool> ExecuteAsync(int id)
    { 
        await _orderRepo.DelAsync(id);
        return true;
    } 
}