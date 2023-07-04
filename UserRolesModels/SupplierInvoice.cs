using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class SupplierInvoice
    {
        [Key]
        public int SupplierInvoiceId { get; set; }
        public int SupplierOrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal GrantTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal UpdatedDate { get; set; }

        public int PaymentStatusId { get; set; }

        public string SupplierInvoiceNumber { get; set; }


        public PaymentStatus PaymentStatus { get; set; }
        public SupplierOrder SupplierOrder { get; set; }


        

        
        public ICollection<SupplierInvoiceItem> SupplierInvoiceItems { get; set; }
    }
}
