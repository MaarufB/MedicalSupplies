using Microsoft.AspNetCore.Mvc;
using MedicalSuppliesWeb.Services.Contracts;
using MedicalSuppliesWeb.ViewModels.Inventory;

namespace MedicalSuppliesWeb.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepo _inventoryRepo;

        public InventoryController(IInventoryRepo inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }
        public IActionResult Index()
        {
            var inventories = _inventoryRepo.GetInventories();
            var inventoryViewModel = inventories.Select(inv => new InventoryVm
            {
                InventoryId = inv.InventoryId,
                ProductId = inv.ProductId,
                ProductName = inv.Product.ProductName,
                QuantityInStock = inv.QuantityInStock,                
                SupplierName = inv.Supplier.SupplierName,
                ReorderLevel = inv.ReorderLevel,
                LastStockUpdate = inv.LastStockUpdate,
                LocationName = inv.Location.LocationName
                
            }).ToList();

            return View(inventoryViewModel);
        }
    }
}
