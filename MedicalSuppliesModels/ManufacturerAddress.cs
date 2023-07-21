using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class ManufacturerAddress
    {
        [Key]
        public int ManufacturerAddressId { get; set; }
        public int ManufacturerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string URL { get; set; }
        public string Zip { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }
}
