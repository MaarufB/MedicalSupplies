using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class FacilityNumber
    {
        [Key]
        public int FacilityNumberId { get; set; }
        public int FacilityId { get; set; }
        public string PhoneNumber { get; set; }

        public Facility Facility { get; set; }
    }
}
