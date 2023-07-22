using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class ManufacturerNumber
    {
        [Key]
        public int ManufacturerNumberId { get; set; }
        public int ManufacturerId { get; set; }
        public string PhoneNumber { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
