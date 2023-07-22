using Microsoft.AspNetCore.Http;
using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.ViewModels.Customer
{
    public class CustomerInvoiceVm
    {

        public CustomerInvoiceVm()
        {
            CustomerInvoiceItems = new List<CustomerInvoiceItemVm>();
        }
        public int CustomerInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        
        public string CustomerInvoiceNo { get; set; }
        public string CustomerName { get; set; }

        public string TicketStatus { get; set; }
        
        public int CustomerOrderId { get; set; }
        
        public DateTime DueDate { get; set; }
        
        public int PaymentStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }
        
        public int TicketStatusId { get; set; }

        
        public string CustomerOrderNo { get; set; }
        public string PaymentStatusName { get; set; }
        public string TicketStatusName { get; set; }
        public List<CustomerInvoiceItemVm> CustomerInvoiceItems { get; set; }

        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }


        public void SetShippingAndBillingAddress(CustomerOrder customerOrder)
        {
            if (customerOrder != null)
            {
                ShippingAddress = customerOrder.ShippingAddress;
                BillingAddress = customerOrder.BillingAddress;
            }
        }




    }
}
