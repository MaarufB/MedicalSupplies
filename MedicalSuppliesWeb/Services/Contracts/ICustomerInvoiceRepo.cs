using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ICustomerInvoiceRepo
    {
        public List<CustomerInvoice> GetAllCustomerInvoices();
    }
}
