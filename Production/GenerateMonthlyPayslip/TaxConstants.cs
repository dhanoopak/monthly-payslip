namespace GenerateMonthlyPayslip
{
    /// <summary>
    /// Project constants
    /// </summary>
    public class TaxConstants
    {
        #region EmployeeTaxStrategy Constants
        public const double LowerTaxRangeLowerBound = 20001;
        public const double LowerTaxRangeUpperBound = 40000;
        public const double LowerTaxRangeRate = 0.1;

        public const double MidTaxRangeLowerBound = 40001;
        public const double MidTaxRangeUpperBound = 80000;
        public const double MidTaxRangeTaxRate = 0.2;

        public const double HigherTaxRangeLowerBound = 80001;
        public const double HigherTaxRangeUpperBound = 180000;
        public const double HigherTaxRangeTaxRate = 0.3;

        public const double TopTaxRangeLowerBound = 180001;
        public const double TopTaxRangeUpperBound = 0;
        public const double TopTaxRangeTaxRate = 0.4;
        #endregion

        #region General Constants
        public const int NumberOfMonths = 12;
        #endregion


        public enum Algorithm
        {
            EmployeeTax = 10,
            AusTax = 20
        }
    }
}