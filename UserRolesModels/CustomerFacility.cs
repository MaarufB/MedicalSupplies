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
        public int CustomerId { get; set; }
        public int FacilityId { get; set; }
        //public int PrescriptionId { get; set; }

        public DateTime DateAdmitted { get; set; }
        public DateTime DateDischarged { get; set; }

        public Customer Customer { get; set; }
        public Facility Facility { get; set; }

    }


}
