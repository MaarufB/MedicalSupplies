using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string ShortState { get; set; }
        public string LongState { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<FacilityAddress> FacilityAddresses { get; set; }
        public ICollection<ManufacturerAddress> ManufacturerAddresses { get; set; }
        public ICollection<SupplierAddress> SupplierAddresses { get; set; }
    }
}
