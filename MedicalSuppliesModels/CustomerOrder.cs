using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public int PaymentMethodId { get; set; }
        public string OrderStatus { get; set; }
        public decimal CustomerOrderTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public int TicketStatusId { get; set; }

        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public TicketStatus TicketStatus { get; set; }
        public ICollection<CustomerOrderItem> CustomerOrderItems { get; set; }
    }
}
