using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class SupplierNumber
    {
        [Key]
        public int SupplierNumberId { get; set; }
        public int SupplierId { get; set; }
        public string PhoneNumber { get; set; }

        public Supplier Supplier { get; set; }
    }
}
