
using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;

namespace Inventory_Dashboard.Services
{
    public class InventoryRepo : IInventoryRepo
    {

        private readonly MSDBContext _context;

        public InventoryRepo(MSDBContext context)
        {
            _context = context;
        }
        public async Task<List<Inventory>> GetAllInventory()
        {
            var inventoryList = await _context.Inventories.Include(i => i.Product).ToListAsync();
            return inventoryList;
        }
    }
}
