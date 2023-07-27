using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.Product;
using MedicalSuppliesWeb.ViewModels.Supplier;

namespace MedicalSuppliesWeb.ViewModels.Search
{
    public class SearchVm
    {
        public IEnumerable<SupplierProfileVm> Suppliers { get; set; }
        public IEnumerable<ProductVm> Products { get; set; }
        public IEnumerable<CustomerProfileVm> Customers { get; set; }
    }
}
