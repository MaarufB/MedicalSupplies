﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesModels
{
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public int CustomerId { get; set; }
        public int InsuranceTypeId { get; set; }
        public string GroupId { get; set; }
        public string PolicyNo { get; set; }
        public bool PrimaryInsurance { get; set; }
        public bool SecondaryInsurance { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime DateExpire { get; set; }
        

        public Customer Customer { get; set; }
        public InsuranceType InsuranceType { get; set; }
    }
}
