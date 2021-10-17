namespace GenerateMonthlyPayslip
{
    public interface ITaxStrategy
    {
        double CalculateTax(double annualSalary);
    }
}
