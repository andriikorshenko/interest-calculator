using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InterestCalculator.Models
{
    public class CalculatorViewModel
    {
        [DisplayName("Loan Period, months")]
        public double Period { get; set; }

        [DisplayName("Interest Rate, %")]
        public double InterestRate { get; set; }

        [DisplayName("Investment Amount, USD")]
        public double InvestmentAmount { get; set; }

        [DisplayName("Total Interest, USD")]
        public double TotalInterest { get; set; }
    }
}
