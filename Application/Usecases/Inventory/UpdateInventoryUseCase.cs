using Application.DTOs.Inventory;
using Application.DTOs.Order;
using Application.Mappers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Inventory
{
    internal class UpdateInventoryUseCase
    {
        private readonly IInventoryRepository _inventoryRepo;

        public UpdateInventoryUseCase(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        public async Task<InventoryResponse?> ExecuteAsync(int id, InventoryRequest request)
        {

            var inventory = await _inventoryRepo.GetByIdAsync(id);

            if (inventory == null) return null;

            

            await _inventoryRepo.UpdateAsync(id, inventory);

            return inventory.ToResponse();

        }
    }
}
