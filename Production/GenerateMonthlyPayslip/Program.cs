using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenerateMonthlyPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            // If command line arguments are given, call ProcessInput function, otherwise read the input from user
            // and split based on the delimiter
            if (args.Any())
            {
                ProcessInput(args[0], args[1]);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Please enter the input.");
                    Console.WriteLine("Sample input format : GenerateMonthlyPayslip \"Mary Song\" 60000");

                    string userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Invalid input. Input format is : GenerateMonthlyPayslip \"Name\" Annual Salary");
                    }
                    else
                    {
                        var inputArray = Regex.Matches(userInput, @"[\""].+?[\""]|[^ ]+")
                            .Select(x => x.Value)
                            .ToList();

                        if (!ProcessInput(inputArray[1], inputArray[2]))
                            continue;
                        
                        Console.WriteLine("Press 'Y' to continue or press any key to exit");

                        string decision = Console.ReadLine();
                        if (!IsApplicationToBeContinued(decision))
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Processes input and print monthly payslip details.
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <param name="yearlyIncome">Annual Salary</param>
        /// <returns>True if success, else return false</returns>
        private static bool ProcessInput(string name, string yearlyIncome)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(yearlyIncome))
            {
                Console.WriteLine("Invalid input. Input format is : GenerateMonthlyPayslip \"Name\" Annual Salary");
                return false;
            }

            double.TryParse(yearlyIncome, out var salaryPerYear);
            if (salaryPerYear < 0)
            {
                Console.WriteLine("Annual salary cannot be negative number. Please correct the input.");
                return false;
            }

            var employee = new Employee(name);
            employee.SetAnnualSalary(salaryPerYear);
            var monthlyPaySlip = employee.GetMonthlyPaySlip();

            Console.WriteLine("\nMonthly Payslip for:  " + monthlyPaySlip.Name);
            Console.WriteLine("Gross Monthly Income: " + monthlyPaySlip.GrossMonthlyIncome.ToCurrency());
            Console.WriteLine("Monthly Income Tax: " + monthlyPaySlip.MonthlyIncomeTax.ToCurrency());
            Console.WriteLine("Net Monthly Income: " + monthlyPaySlip.NetMonthlyIncome.ToCurrency());

            return true;
        }

        /// <summary>
        /// Checks if the application to be exited from the loop
        /// </summary>
        /// <param name="decision">Decision string</param>
        /// <returns>True if user decides to continue running the application(Y or y), else return false</returns>
        private static bool IsApplicationToBeContinued(string decision)
        {
            return decision?.ToLower() == "y";
        }
    }
}
