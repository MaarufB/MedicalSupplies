using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<SupplierAddress> SupplierAddresses { get; set; }
        public ICollection<SupplierNumber> SupplierNumbers { get; set; }
        public ICollection<SupplierOrder> SupplierOrders { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
