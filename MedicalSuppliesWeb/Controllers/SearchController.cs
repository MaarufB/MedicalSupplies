using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Customer;
using MedicalSuppliesWeb.ViewModels.Product;
using MedicalSuppliesWeb.ViewModels.Search;
using MedicalSuppliesWeb.ViewModels.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSuppliesWeb.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string results)
        {
            var searchViewModel = new SearchVm();

            // Deserialize the JSON string into separate lists for products, suppliers, and customers
            var productResults = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ProductVm>>(results);
            var supplierResults = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<SupplierProfileVm>>(results);
            var customerResults = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CustomerProfileVm>>(results);

            // Assign the deserialized lists to the corresponding properties of the ViewModel
            searchViewModel.Products = productResults;
            searchViewModel.Suppliers = supplierResults;
            searchViewModel.Customers = customerResults;

            return View(searchViewModel);
        }
    }
}
