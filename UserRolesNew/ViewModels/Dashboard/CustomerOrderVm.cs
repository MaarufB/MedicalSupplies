namespace UserRolesNew.ViewModels.Dashboard
{
    public class CustomerOrderVm
    {
        public int CustomerOrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal CustomerOrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerName { get; set; }
    }
}
