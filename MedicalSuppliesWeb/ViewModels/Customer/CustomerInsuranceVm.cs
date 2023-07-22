using MedicalSuppliesModels;

namespace UserRolesNew.ViewModels.Customer
{
    public class CustomerInsuranceVm
    {
        public int InsuranceId { get; set; }
        public int CustomerId { get; set; }
        public int InsuranceTypeId { get; set; }
        public string GroupId { get; set; }
        public string PolicyNo { get; set; }
        public bool PrimaryInsurance { get; set; }
        public bool SecondaryInsurance { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime DateExpire { get; set; }

        public CustomerInsuranceTypeVm InsuranceType { get; set; }
    }
}
