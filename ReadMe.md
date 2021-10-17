# Employee Monthly Pay Slip

`Employee Monthly Pay Slip` is a console application that calculates monthly payslip and displays the employee name, gross monthly income, monthly income tax and net monthly income for a given employee.

# Prerequisites

.NET Core 3.1 SDK

## How to Build Employee Monthly Pay Slip

1. Open the console application solution in Visual Studio 2019.
2. Go to Build menu and rebuild the application.
3. Binaries will be generated in 'GenerateMonthlyPayslip\bin\netcoreapp3.1' folder.

## How to Run

You can run the application in two ways.

- Option 1

1.  In a command prompt, go to bin directory in 'GenerateMonthlyPayslip\bin\netcoreapp3.1' folder

2.  Input command in following format:

        GenerateMonthlyPayslip "Mary Song" 60000

- Option 2

1.  Go to console application directory in 'GenerateMonthlyPayslip\bin\netcoreapp3.1' and run `GenerateMonthlyPayslip.exe`

2.  Input command in following format:

        GenerateMonthlyPayslip "Mary Song" 60000

## How to Run the tests

1. Open the solution in Visual Studio 2019
2. Go to test project 'MonthlyPayslipTest' in the solution
3. Run the tests by using Test menu -> 'Run All Tests' option in Visual Studio

# Design

**GenerateMonthlyPayslip** is implemented considering **SOLID** design principles and **Strategy design pattern**.

A strategy design patten is used for future extension and to support additional tax calculations like various employee tax rates (for different countries and year),'Foreign residents' 'Working holiday makers' etc.

`Employee` : Class that triggers the calculation of incomeTax and return the output.

`TaxCalculator` : Context class that trigger strategy.

`ITaxStrategy` : Interface that has method `CalculateTax`, which forces extended strategy classes to handle `CalculateTax`.

`EmployeeTaxStrategy` : Class that implements `CalculateTax` based on various tax rates and range.

Single Responsibility Principle, Open Close Principle, Dependency Injection Principle are considered in the design.

An extension method for double data type is added to print the value in currency format. Implementation can be referred in `Utility` class and method name is `ToCurrency`.

`GenerateMonthlyPayslipTest` : Unit tests and integration tests for testing tax calculation is added here.

`UtilityTests` : Unit tests for extension method `ToCurrency`.
