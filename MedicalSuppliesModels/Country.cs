using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        
        public ICollection<FacilityAddress> FacilityAddresses { get; set; }        
        public ICollection<ManufacturerAddress> ManufacturerAddresses { get; set; }
        public ICollection<SupplierAddress> SupplierAddresses { get; set; }
    }
}
