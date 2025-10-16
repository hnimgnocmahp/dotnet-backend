using Application.DTOs.Inventory;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.UseCases;

public class CreateInventoryUsecase
{
    private readonly IInventoryRepository _inventoryRepo;

    public CreateInventoryUsecase(IInventoryRepository inventoryRepo)
    {
        _inventoryRepo = inventoryRepo;
    }

    public async Task<InventoryResponse?> ExecuteAsync(InventoryRequest request)
    {
        var inventory = request.ToEntity(); // mapping từ input DTO sang domain
        await _inventoryRepo.AddAsync(inventory); // làm việc với entity
        return inventory.ToResponse(); // mapping domain sang output DTO
    }
}