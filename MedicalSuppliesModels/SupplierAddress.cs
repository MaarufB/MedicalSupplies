using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class SupplierAddress
    {
        [Key]
        public int SupplierAddressId { get; set; }
        public int SupplierId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Zip { get; set; }

        public Supplier Supplier { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}
