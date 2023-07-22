using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

        public ICollection<CustomerOrder> CustomerOrders { get; set; }
        public ICollection<SupplierOrder> SupplierOrders { get; set; }
    }
}
