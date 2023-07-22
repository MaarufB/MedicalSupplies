using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class PaymentStatus
    {
        [Key]
        public int PaymentStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}
