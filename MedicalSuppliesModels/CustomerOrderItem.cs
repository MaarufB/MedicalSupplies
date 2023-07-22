using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class CustomerOrderItem
    {
        [Key]
        public int CustomerOrderItemId { get; set; }
        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public CustomerOrder CustomerOrder { get; set; }
        public Product Product { get; set; }
    }
}
