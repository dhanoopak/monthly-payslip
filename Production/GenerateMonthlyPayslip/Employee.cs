namespace GenerateMonthlyPayslip
{
    public class Employee
    {
        private string Name { get; }
        private double AnnualSalary { get; set; }

        private TaxConstants.Algorithm _algorithm;

        public Employee(string name)
        {
            Name = name;
            _algorithm = TaxConstants.Algorithm.EmployeeTax;
        }

        /// <summary>
        /// Sets annual salary of an employee
        /// </summary>
        /// <param name="annualSalary">Annual salary</param>
        public void SetAnnualSalary(double annualSalary)
        {
            AnnualSalary = annualSalary;
        }

        /// <summary>
        /// Returns Monthly payslip containing monthly income(gross and net) and tax details
        /// </summary>
        /// <returns>MonthlyPaySlip object</returns>
        public MonthlyPaySlip GetMonthlyPaySlip()
        {
            var monthlyPaySlip = new MonthlyPaySlip
            {
                Name = Name,
            };

            if (AnnualSalary <= 0)
                return monthlyPaySlip;

            monthlyPaySlip.GrossMonthlyIncome = GetGrossMonthlyIncome();
            monthlyPaySlip.MonthlyIncomeTax = GetMonthlyIncomeTax();
            monthlyPaySlip.NetMonthlyIncome = GetNetMonthlyIncome(monthlyPaySlip);

            return monthlyPaySlip;
        }
        
        private double GetGrossMonthlyIncome()
        {
            return AnnualSalary / TaxConstants.NumberOfMonths;
        }

        private double GetMonthlyIncomeTax()
        {
            return GetIncomeTax(AnnualSalary) / TaxConstants.NumberOfMonths;
        }

        /// <summary>
        /// Trigger tax calculation and return tax value
        /// </summary>
        /// <param name="taxableIncome">Taxable income</param>
        /// <returns>Tax for given annual income</returns>
        private double GetIncomeTax(double taxableIncome)
        {
            TaxCalculator taxCalculator;
            switch (_algorithm)
            {
                case TaxConstants.Algorithm.AusTax:
                    taxCalculator = new TaxCalculator(new EmployeeTaxStrategy());
                    break;

                default:
                    taxCalculator = new TaxCalculator(new EmployeeTaxStrategy());
                    break;
            }

            // var taxCalculator = new TaxCalculator(new EmployeeTaxStrategy());

            return taxCalculator.GetTax(taxableIncome);
        }

        private static double GetNetMonthlyIncome(MonthlyPaySlip monthlyPaySlip)
        {
            return monthlyPaySlip.GrossMonthlyIncome - monthlyPaySlip.MonthlyIncomeTax;
        }

        public void SetAlgoirthm(TaxConstants.Algorithm ausTax)
        {
            _algorithm = ausTax;
        }
    }
}
