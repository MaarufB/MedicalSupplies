using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface ISupplierInvoiceRepo
    {
        public List<SupplierInvoice> GetAllSupplierInvoices();
    }
}
