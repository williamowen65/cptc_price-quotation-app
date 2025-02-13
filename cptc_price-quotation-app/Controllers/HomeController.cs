using System.Diagnostics;
using cptc_price_quotation_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace cptc_price_quotation_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new PriceQuoteModel();

            return View(model);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [ActionName("CalculateQuote")]
        public IActionResult CalculateQuote(PriceQuoteModel model)
        {
            _logger.LogInformation("Index POST method called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Subtotal: {Subtotal}, DiscountPercent: {DiscountPercent}", model.Subtotal, model.DiscountPercent);
                // Process the form data here
                // For example, save the data to the database or perform calculations

                // Redirect to a confirmation page or display a success message
                //return RedirectToAction("Success");

                model.DiscountAmount = model.Subtotal * (model.DiscountPercent / 100);
                model.Total = model.Subtotal - model.DiscountAmount;

                _logger.LogInformation("AFter calc");
                _logger.LogInformation("Discount : " + model.DiscountAmount);
                _logger.LogInformation("Total : " + model.Total);


                return View("Index", model);
            }

            _logger.LogWarning("Model is not valid.");
            // If the model state is not valid, return the view with the model to display validation errors
            return View("Index", model);
        }

        
    }
}
