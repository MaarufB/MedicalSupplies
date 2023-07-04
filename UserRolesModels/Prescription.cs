using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateWritten { get; set; }
        public string DoctorName { get; set; }
        public string DoctorContact { get; set; }
        public string Comments { get; set; }
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        public Customer Customer { get; set; }
        //public ICollection<CustomerFacility> CustomerFacilities { get; set; }
        
    }
}
