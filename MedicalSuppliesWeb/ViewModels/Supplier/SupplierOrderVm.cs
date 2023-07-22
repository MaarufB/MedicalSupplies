using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierOrderVm
    {
        public SupplierOrderVm()
        {
            SupplierOrderItems = new List<SupplierOrderItemVm>();
        }
        public int SupplierOrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal SupplierOrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string SupplierName { get; set; }

        public string TicketStatus { get; set; }





        
        public int SupplierId { get; set; }
       
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public int PaymentMethodId { get; set; }
        
        
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public int TicketStatusId { get; set; }

        // Additional properties from related entities if needed
        
        public string PaymentMethodName { get; set; }
        
        public List<SupplierOrderItemVm> SupplierOrderItems { get; set; }





    }
}
