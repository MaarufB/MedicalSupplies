using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSuppliesSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly MSDBContext _context;

        public SearchController(MSDBContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetProducts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(new List<Product>());
            }

            var products = _context.Products
                .Where(p => p.ProductName.Contains(query))
                .ToList();

            return Ok(products);
        }

        [HttpGet("customers")]
        public ActionResult<IEnumerable<Customer>> GetCustomers(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(new List<Customer>());
            }

            var customers = _context.Customers
                 .Where(c => c.FirstName.Contains(query) || c.LastName.Contains(query))
                  .ToList();

            //need to modify this to have full name or part of it

            return Ok(customers);
        }

        [HttpGet("suppliers")]
        public ActionResult<IEnumerable<Supplier>> GetSuppliers(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(new List<Supplier>());
            }

            var suppliers = _context.Suppliers
                .Where(s => s.SupplierName.Contains(query))
                .ToList();

            //need to modify this to have full name or part of it

            return Ok(suppliers);
        }
    }
}
