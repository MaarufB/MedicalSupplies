using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public ICollection<CustomerInvoiceItem> CustomerInvoiceItems { get; set; }
        public ICollection<CustomerOrderItem> CustomerOrderItems { get; set; }        
        public ICollection<SupplierOrderItem> SupplierOrderItems { get; set; }
    }
}
