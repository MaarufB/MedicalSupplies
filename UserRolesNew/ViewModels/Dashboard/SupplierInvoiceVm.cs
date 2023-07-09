namespace UserRolesNew.ViewModels.Dashboard
{
    public class SupplierInvoiceVm
    {
        public int SupplierInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public string SupplierName { get; set; }

        public string TicketStatus { get; set; }
    }
}
