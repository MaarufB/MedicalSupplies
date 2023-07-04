﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRolesModels
{
    public class CustomerNumber
    {
        [Key]
        public int CustomerNumberId { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }

        public Customer Customer { get; set; }
    }
}
