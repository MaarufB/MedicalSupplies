using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System.Diagnostics;
using UserRolesNew.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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










        [HttpGet]
        [Authorize] // Optionally, restrict access to authenticated users
        public IActionResult UploadFile()
        {
            return View(null);
        }



        [HttpPost]
        [Authorize] // Optionally, restrict access to authenticated users
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // Handle the case where no file is uploaded
                // You can return an error message or redirect to a view with an error message
                return View("Error");
            }

            // Get the file name and extension
            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);

            // Generate a unique file name to avoid potential conflicts
            var uniqueFileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);

            // Combine the file server directory path and the unique file name
            var fileSavePath = Path.Combine("D:\\AAIT\\AAIT\\Class Code\\Natasha\\MSP\\UserRolesTest\\Jul 7 Copy\\File Server", uniqueFileName);

            // Save the uploaded file to the file server directory
            using (var stream = new FileStream(fileSavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Optionally, you can perform additional actions or return a success message
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}