using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int QuantityInStock { get; set; }
        public int SupplierId { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime LastStockUpdate { get; set; }
        public int LocationId { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public Location Location { get; set; }
    }
}
