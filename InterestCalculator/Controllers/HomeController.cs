using InterestCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalculator.Controllers
{
    public class HomeController : Controller
    {
        private const double TOTAL_MONTHS_IN_A_YEAR = 12;

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
            
            double totalMonths = calculator.Period * TOTAL_MONTHS_IN_A_YEAR;
            double restBody = calculator.InvestmentAmount;
            double bodyFixedPayment = default;
            double totalInterest = default;

            for (int i = 0; i < totalMonths; i++)
            {
                restBody = restBody - bodyFixedPayment;
                totalInterest += (restBody - bodyFixedPayment) / totalMonths * calculator.InterestRate / 100;
                bodyFixedPayment = calculator.InvestmentAmount / totalMonths;
            }

            var cwm = new CalculatorViewModel()
            {
                Period = totalMonths,
                InterestRate = calculator.InterestRate,
                InvestmentAmount = calculator.InvestmentAmount,
                TotalInterest = totalInterest
            };

            return RedirectToAction("Output", cwm);
        }

        [HttpGet]
        public IActionResult Output(CalculatorViewModel cwm)
        {
            return View(cwm);
        }
    }
}