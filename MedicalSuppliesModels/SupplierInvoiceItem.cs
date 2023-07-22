using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class SupplierInvoiceItem
    {
        [Key]
        public int SupplierInvoiceItemId { get; set; }
        public int SupplierInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public SupplierInvoice SupplierInvoice { get; set; }
        public Product Product { get; set; }
    }
}
