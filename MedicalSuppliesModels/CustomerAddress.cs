using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class CustomerAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string Zip { get; set; }

        public Customer Customer { get; set; }
        public State State { get; set; }

        //public Country Country { get; set; }
    }
}
