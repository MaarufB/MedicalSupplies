using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class Colour
    {
        [Key]
        public int ColourId { get; set; }
        public string ColourName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
