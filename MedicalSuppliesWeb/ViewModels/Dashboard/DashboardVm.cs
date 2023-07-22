using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.Supplier;

namespace MedicalSuppliesWeb.ViewModels.Dashboard
{
    public class DashboardVm
    {
        public List<CustomerInvoiceVm> CustomerInvoices { get; set; }
        public List<SupplierInvoiceVm> SupplierInvoices { get; set; }
        public List<CustomerOrderVm> CustomerOrders { get; set; }
        public List<SupplierOrderVm> SupplierOrders { get; set; }
    }
}
