using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class SupplierOrder
    {
        [Key]
        public int SupplierOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public int PaymentMethodId { get; set; }
        public string OrderStatus { get; set; }
        public decimal SupplierOrderTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public int TicketStatusId { get; set; }

        public Supplier Supplier { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public TicketStatus TicketStatus { get; set; }
        public ICollection<SupplierOrderItem> SupplierOrderItems { get; set; }
    }
}
