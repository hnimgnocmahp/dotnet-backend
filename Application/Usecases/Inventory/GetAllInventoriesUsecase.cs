using Application.DTOs.Inventory;
using Application.DTOs.Product;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class GetAllInventoriesUseCase
{
    private readonly IInventoryRepository _inventoryRepo;

    public GetAllInventoriesUseCase(IInventoryRepository inventoryRepo)
    {
        _inventoryRepo = inventoryRepo;
    }

    public async Task<IEnumerable<InventoryResponse>> ExecuteAsync()
    {
        var inventories = await _inventoryRepo.GetAllAsync();
        return inventories.ToResponse();
    }
}