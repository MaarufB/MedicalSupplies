using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ICustomerInvoiceRepo
    {
        public List<CustomerInvoice> GetAllCustomerInvoices();
    }
}
