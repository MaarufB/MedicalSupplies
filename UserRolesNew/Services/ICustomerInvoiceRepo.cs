using UserRolesModels;

namespace UserRolesNew.Services
{
    public interface ICustomerInvoiceRepo
    {
        public List<CustomerInvoice> GetAllCustomerInvoices();
    }
}
