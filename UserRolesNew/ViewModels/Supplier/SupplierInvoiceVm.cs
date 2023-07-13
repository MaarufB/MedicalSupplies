using UserRolesModels;

namespace UserRolesNew.ViewModels.Supplier
{
    public class SupplierInvoiceVm
    {

        public SupplierInvoiceVm()
        {
            SupplierInvoiceItems = new List<SupplierInvoiceItemVm>();
        }
        public int SupplierInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public string SupplierName { get; set; }

        public string TicketStatus { get; set; }

       
        public int SupplierOrderId { get; set; }
        
        public DateTime DueDate { get; set; }
        
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PaymentStatusId { get; set; }
        
        public int TicketStatusId { get; set; }

        // Additional properties from related entities if needed
        public string SupplierOrderNo { get; set; }
        public string PaymentStatusName { get; set; }
        
        public List<SupplierInvoiceItemVm> SupplierInvoiceItems { get; set; }




    }
}
