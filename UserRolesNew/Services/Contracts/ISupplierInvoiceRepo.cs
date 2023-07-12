using UserRolesModels;

namespace UserRolesNew.Services.Contracts
{
    public interface ISupplierInvoiceRepo
    {
        public List<SupplierInvoice> GetAllSupplierInvoices();
    }
}
