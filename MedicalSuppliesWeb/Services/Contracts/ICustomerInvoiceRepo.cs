using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ICustomerInvoiceRepo
    {
        public List<CustomerInvoice> GetAllCustomerInvoices();
    }
}
