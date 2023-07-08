namespace UserRolesModels
{
    public class TicketStatus
    {
        public int TicketStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }
        public ICollection<SupplierOrder> SupplierOrders { get; set; }
        public ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}