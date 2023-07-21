namespace UserRolesNew.ViewModels.Inventory
{
    public class InventoryVm
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityInStock { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime LastStockUpdate { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
