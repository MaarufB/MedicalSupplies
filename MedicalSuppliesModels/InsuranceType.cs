using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class InsuranceType
    {
        [Key]
        public int InsuranceTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<Insurance> Insurances { get; set; }
    }
}
