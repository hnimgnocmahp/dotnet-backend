using Application.DTOs.Inventory;
using Application.DTOs.Order;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetInventoryByProductIdUseCase
{
    private readonly IInventoryRepository _inventoryRepo;

    public GetInventoryByProductIdUseCase(IInventoryRepository inventoryRepo)
    {
        _inventoryRepo = inventoryRepo;
    }

    public async Task<InventoryResponse?> ExecuteAsync(int id)
    {
        var inventory = await _inventoryRepo.GetByIdAsync(id);

        if (inventory == null) return null;
        return inventory.ToResponse();
    }
}