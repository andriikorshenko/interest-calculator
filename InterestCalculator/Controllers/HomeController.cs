using InterestCalculator.Logic;
using InterestCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalculator.Controllers
{
    public class HomeController : Controller
    {  
        [Route("")]
        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Input(Calculator calculator)
        {
            if (!ModelState.IsValid)
            {
                return View(calculator);
            }

            return RedirectToAction("Output", 
                new AnnuityCalculation(calculator).Calculate());
        }

        [HttpGet]
        public IActionResult Output(CalculatorViewModel cwm)
        {
            return View(cwm);
        }
    }
}