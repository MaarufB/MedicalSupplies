using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<CustomerFacility> CustomerFacilities { get; set; }
        public ICollection<FacilityAddress> FacilityAddresses { get; set; }
        public ICollection<FacilityNumber> FacilityNumbers { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
