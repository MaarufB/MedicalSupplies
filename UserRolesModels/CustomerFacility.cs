using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class CustomerFacility
    {
        [Key]
        [Column(Order = 1)]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FacilityId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int PrescriptionId { get; set; }

        public DateTime DateAdmitted { get; set; }
        public DateTime DateDischarged { get; set; }

        public Customer Customer { get; set; }
        public Facility Facility { get; set; }
        public Prescription Prescription { get; set; }
    }


}
