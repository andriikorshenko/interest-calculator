using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InterestCalculator.Models
{
    public class Calculator
    {
        [Required]
        [DisplayName("Agreement Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AgreementDate { get; set; }

        [Required]
        [Range(1, 6, ErrorMessage = "The numbers should be between 1 and 5 years")]
        public double Period { get; set; }

        [Required]
        [DisplayName("Interest Rate, %")]
        [Range(0, 100, ErrorMessage = "The numbers should be between 0 and 100 %")]
        public double InterestRate { get; set; }

        [Required]
        [DisplayName("Investment Amount, USD")]
        public double InvestmentAmount { get; set; }
    }
}
