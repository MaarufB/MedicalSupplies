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

        public IActionResult AccessDenied()
        {
            return View();
        }



        [HttpPost]
        public ActionResult GeneratePDF(string htmlContent)
        {
            HtmlToPdf converter = new HtmlToPdf();
            var htmlDocument = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title> - UserRolesNew</title>\r\n    <link rel=\"stylesheet\" href=\"https://localhost:7247/lib/bootstrap/dist/css/bootstrap.min.css\" />\r\n    \r\n</head>\r\n<body>{htmlContent}\r\n\r\n\r\n</body>\r\n</html>\r\n";
            PdfDocument doc = converter.ConvertHtmlString(htmlDocument);
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