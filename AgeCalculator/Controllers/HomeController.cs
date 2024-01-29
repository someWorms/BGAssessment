using AgeCalculator.Models;
using AgeCalculator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AgeCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculatorService _calculatorService;

        public HomeController(ILogger<HomeController> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        
        /// <summary>
        /// Get index page 
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Post index page
        /// </summary>
        /// <param name="model">Birthday as <c>AgeViewModel</c></param>
        /// <returns>Processed <c>AgeViewModel</c> </returns>
        [HttpPost]
        public IActionResult Index([NotNull] AgeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _calculatorService.CalculateDate(model);
                return View(model);
            }

            _logger.LogInformation($"Errors: {ModelState.ErrorCount}");

            foreach (var error in ModelState.Values.SelectMany(modelState => modelState.Errors))
            {
                _logger.LogError($"{error.ErrorMessage}");
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
