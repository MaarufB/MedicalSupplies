using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Diagnostics;
using UserRolesNew.Models;

namespace UserRolesNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NPILookup()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpPost]
        public ActionResult GeneratePDF(string htmlContent)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(htmlContent);
            byte[] pdf = doc.Save();
            doc.Close();
            return File(pdf, "application/pdf", "output.pdf");
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}