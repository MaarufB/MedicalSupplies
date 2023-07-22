using MedicalSuppliesModels;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface ISupplierInvoiceRepo
    {
        public List<SupplierInvoice> GetAllSupplierInvoices();
    }
}
