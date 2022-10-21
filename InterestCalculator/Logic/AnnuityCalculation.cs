using InterestCalculator.Models;

namespace InterestCalculator.Logic
{
    public class AnnuityCalculation
    {
        private const double TOTAL_MONTHS_IN_A_YEAR = 12;
        private readonly Calculator _calculator;
        private CalculatorViewModel? _cwm;
        private double _totalMonths;
        private double _restBody;
        private double _bodyFixedPayment;
        private double _totalInterest;

        public AnnuityCalculation(Calculator calculator)
        {
            _calculator = calculator;
        }

        public CalculatorViewModel Calculate()
        {
            _totalMonths = _calculator.Period * TOTAL_MONTHS_IN_A_YEAR;
            _restBody = _calculator.InvestmentAmount;
            _bodyFixedPayment = _calculator.InvestmentAmount / _totalMonths;
            _totalInterest = _restBody / _totalMonths * _calculator.InterestRate / 100;

            for (int i = 0; i < _totalMonths - 1; i++)
            {
                _restBody = _restBody - _bodyFixedPayment;
                _totalInterest += _restBody / _totalMonths * _calculator.InterestRate / 100;
            }

            _cwm = new()
            {
                Period = _totalMonths,
                InterestRate = _calculator.InterestRate,
                InvestmentAmount = _calculator.InvestmentAmount,
                TotalInterest = _totalInterest
            };

            return _cwm;
        }
    }
}
