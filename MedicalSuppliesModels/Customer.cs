using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public int GenderId { get; set; }
        public bool Active { get; set; }

        public Gender Gender { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<CustomerFacility> CustomerFacilities { get; set; }

        //public ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public ICollection<CustomerNumber> CustomerNumbers { get; set; }
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
        public ICollection<Insurance> Insurances { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
