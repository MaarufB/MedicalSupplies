using MedicalSuppliesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ICustomerInvoiceRepo
    {
        public List<CustomerInvoice> GetAllCustomerInvoices();
    }
}
