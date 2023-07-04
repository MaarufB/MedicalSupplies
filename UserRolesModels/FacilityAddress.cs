using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class FacilityAddress
    {
        [Key]
        public int FacilityAddressId { get; set; }
        public int FacilityId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public Facility Facility { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}
