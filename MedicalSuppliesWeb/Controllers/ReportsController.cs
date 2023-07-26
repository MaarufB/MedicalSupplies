using MedicalSuppliesModels;
using MedicalSuppliesServices.Services.Contracts;
using MedicalSuppliesWeb.ViewModels.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSuppliesWeb.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IInventoryRepo _inventoryRepo;

        public ReportsController(IInventoryRepo inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }
        public IActionResult Index()
        {
            
            var inventories = _inventoryRepo.GetInventories();

            
            var inventoryViewModels = MapInventoryToInventoryVm(inventories);

            
            return View(inventoryViewModels);
        }

        private List<InventoryVm> MapInventoryToInventoryVm(List<Inventory> inventories)
        {
            var inventoryViewModels = new List<InventoryVm>();

            foreach (var inventory in inventories)
            {
                var inventoryVm = new InventoryVm
                {
                    InventoryId = inventory.InventoryId,
                    ProductId = inventory.ProductId,
                    ProductName = inventory.Product.ProductName,
                    QuantityInStock = inventory.QuantityInStock,
                    SupplierId = inventory.SupplierId,
                    SupplierName = inventory.Supplier.SupplierName,
                    ReorderLevel = inventory.ReorderLevel,
                    LastStockUpdate = inventory.LastStockUpdate,
                    LocationId = inventory.LocationId,
                    LocationName = inventory.Location.LocationName
                };

                inventoryViewModels.Add(inventoryVm);
            }

            return inventoryViewModels;
        }
    }
}
