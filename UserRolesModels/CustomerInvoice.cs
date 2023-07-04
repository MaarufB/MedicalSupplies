using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class CustomerInvoice
    {
        [Key]
        public int CustomerInvoiceId { get; set; }
        public int CustomerOrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string CustomerInvoiceNo { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public ICollection<CustomerInvoiceItem> CustomerInvoiceItems { get; set; }
    }
}
