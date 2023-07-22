using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string AccountNo { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ManufacturerAddress> ManufacturerAddresses { get; set; }
        public ICollection<ManufacturerNumber> ManufacturerNumbers { get; set; }
    }
}
