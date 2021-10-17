namespace GenerateMonthlyPayslip
{
    /// <summary>
    /// Context class that refers to the EmployeeTaxStrategy(Strategy) interface for performing tax calculation
    /// </summary>
    public class TaxCalculator
    {
        private readonly ITaxStrategy _taxStrategy;

        public TaxCalculator(ITaxStrategy taxStrategy)
        {
            _taxStrategy = taxStrategy;
        }

        /// <summary>
        /// Trigger tax calculation and return tax value
        /// </summary>
        /// <param name="annualSalary">Annual salary of an employee</param>
        /// <returns>Tax for given annual salary</returns>
        public double GetTax(double annualSalary)
        {
            return _taxStrategy.CalculateTax(annualSalary);
        }
    }
}