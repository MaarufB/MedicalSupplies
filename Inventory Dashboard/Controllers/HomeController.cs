using Microsoft.AspNetCore.Mvc;

namespace Inventory_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
