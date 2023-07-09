namespace UserRolesNew.ViewModels.Dashboard
{
    public class SupplierOrderVm
    {
        public int SupplierOrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal SupplierOrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string SupplierName { get; set; }
    }
}
