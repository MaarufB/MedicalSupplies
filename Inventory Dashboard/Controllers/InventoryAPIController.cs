using Inventory_Dashboard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRolesModels;

namespace Inventory_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryAPIController : ControllerBase
    {
        private readonly IInventoryRepo _inventoryRepo;
        public InventoryAPIController(IInventoryRepo inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        [HttpGet]
        public async Task<List<Inventory>> GetAllInventory()
        {
            var inventoryList = await _inventoryRepo.GetAllInventory();
            return inventoryList; 
        }
    }
}
