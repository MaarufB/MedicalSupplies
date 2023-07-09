namespace UserRolesNew.ViewModels.Dashboard
{
    public class CustomerInvoiceVm
    {
        public int CustomerInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerInvoiceNo { get; set; }
        public string CustomerName { get; set; }
    }
}
