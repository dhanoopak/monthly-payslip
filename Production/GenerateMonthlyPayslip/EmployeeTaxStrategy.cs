namespace GenerateMonthlyPayslip
{
    public class EmployeeTaxStrategy : ITaxStrategy
    {
        private double UpperBound { get; set; }
        private double LowerBound { get; set; }
        private double TaxRate { get; set; }

        /// <summary>
        /// Calculates tax based on various tax slab and rate
        /// </summary>
        /// <param name="annualSalary">Taxable income</param>
        /// <returns>Tax for given taxable income</returns>
        public virtual double CalculateTax(double annualSalary)
        {
            double taxForIncome = 0.0;

            SetTaxParams(TaxConstants.LowerTaxRangeLowerBound, TaxConstants.LowerTaxRangeUpperBound, TaxConstants.LowerTaxRangeRate);
            taxForIncome += CalculateTaxValueForGivenSlab(annualSalary);

            SetTaxParams(TaxConstants.MidTaxRangeLowerBound, TaxConstants.MidTaxRangeUpperBound, TaxConstants.MidTaxRangeTaxRate);
            taxForIncome += CalculateTaxValueForGivenSlab(annualSalary);

            SetTaxParams(TaxConstants.HigherTaxRangeLowerBound, TaxConstants.HigherTaxRangeUpperBound, TaxConstants.HigherTaxRangeTaxRate);
            taxForIncome += CalculateTaxValueForGivenSlab(annualSalary);

            SetTaxParams(TaxConstants.TopTaxRangeLowerBound, TaxConstants.TopTaxRangeUpperBound, TaxConstants.TopTaxRangeTaxRate);
            taxForIncome += CalculateTaxValueForGivenSlab(annualSalary);

            return taxForIncome;
        }
        
        private void SetTaxParams(double lowerBound, double upperBound, double taxRate)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            TaxRate = taxRate;
        }
        
        /// <summary>
        /// Generic tax calculation logic.
        /// </summary>
        /// <param name="annualSalary">Taxable income.</param>
        /// <returns>Calculated tax value.</returns>
        private double CalculateTaxValueForGivenSlab(double annualSalary)
        {
            double slab1MinThreshold = LowerBound - 1;
            double slab1MaxThreshold = UpperBound;

            if (IsAnnualSalaryLessThanThreshold(annualSalary, slab1MinThreshold)) return 0;

            double salaryToBeConsideredForTax = slab1MaxThreshold - slab1MinThreshold;

            if (slab1MaxThreshold == 0)
            {
                return HandleTopTaxRate(annualSalary, slab1MinThreshold);
            }

            if (IsTaxUpperBoundLessThanAnnualSalary(annualSalary, slab1MaxThreshold))
            {
                salaryToBeConsideredForTax = annualSalary - slab1MinThreshold;
            }

            return salaryToBeConsideredForTax * TaxRate;
        }

        /// <summary>
        /// For top tax slab, there is no upper bound. Tax falling under highest slab is calculated here.
        /// </summary>
        /// <param name="annualSalary">Taxable income.</param>
        /// <param name="slab1MinThreshold">Lower bound value</param>
        /// <returns>Tax for highest tax slab.</returns>
        private double HandleTopTaxRate(double annualSalary, double slab1MinThreshold)
        {
           
            var salaryToBeConsideredForTax = annualSalary - slab1MinThreshold;

            return salaryToBeConsideredForTax * TaxRate;
        }

        private static bool IsAnnualSalaryLessThanThreshold(double annualSalary, double threshold)
        {
            return annualSalary < threshold;
        }

        private static bool IsTaxUpperBoundLessThanAnnualSalary(double annualSalary, double threshold)
        {
            return threshold > annualSalary;
        }
    }
}