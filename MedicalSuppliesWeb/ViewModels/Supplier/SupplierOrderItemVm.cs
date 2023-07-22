namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierOrderItemVm
    {
        public int SupplierOrderItemId { get; set; }
        public int SupplierOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        // Additional properties from related entities if needed
        public string ProductName { get; set; }
    }
}
