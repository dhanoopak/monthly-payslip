using GenerateMonthlyPayslip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MonthlyPayslipTest
{
    [TestClass]
    public class GenerateMonthlyPayslipTest
    {
        private const string EmployeeName = "John Citizen";
        private Employee _employee;

        #region Setup - Initialialisation code for all test cases
        [TestInitialize]
        public void SetEmployeeDetails()
        {
            _employee = new Employee(EmployeeName);
        }
        #endregion

        [TestMethod]
        public void EmployeesMonthlySalaryReturnsZeroWhenAnnualSalaryIsNegative()
        {
            // Arrange
            _employee.SetAnnualSalary(-100000);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(0, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(0, monthlyPaySlip.MonthlyIncomeTax);
            Assert.AreEqual(0, monthlyPaySlip.NetMonthlyIncome);
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReturnsZeroWhenAnnualSalaryIsZero()
        {
            // Arrange
            _employee.SetAnnualSalary(0.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(0, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(0, monthlyPaySlip.MonthlyIncomeTax);
            Assert.AreEqual(0, monthlyPaySlip.NetMonthlyIncome);
        }


        [TestMethod]
        public void EmployeesMonthlySalaryTakeNoTaxWhenSalaryIsBelowTwentyThousandTest()
        {
            // Arrange
            _employee.SetAnnualSalary(12000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(1000, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(0, monthlyPaySlip.MonthlyIncomeTax);
            Assert.AreEqual(1000, monthlyPaySlip.NetMonthlyIncome);
        }

        [TestMethod]
        public void EmployeesMonthlySalaryTakeNoTaxWhenSalaryIsTwentyThousandTest()
        {
            // Arrange
            _employee.SetAnnualSalary(20000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(1666.67, Math.Round(monthlyPaySlip.GrossMonthlyIncome, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(0, monthlyPaySlip.MonthlyIncomeTax);
            Assert.AreEqual(1666.67, Math.Round(monthlyPaySlip.NetMonthlyIncome, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReducesTaxWhenInFirstTaxSlabTest()
        {
            // Arrange
            _employee.SetAnnualSalary(30000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(2500, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(83.33, Math.Round(monthlyPaySlip.MonthlyIncomeTax, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(2416.67, Math.Round(monthlyPaySlip.NetMonthlyIncome, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReducesTaxWhenInSecondTaxSlabTest()
        {
            // Arrange
            _employee.SetAnnualSalary(60000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(5000, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(500, monthlyPaySlip.MonthlyIncomeTax);
            Assert.AreEqual(4500, monthlyPaySlip.NetMonthlyIncome);
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReducesTaxWhenInThirdTaxSlabTest()
        {
            // Arrange
            _employee.SetAnnualSalary(180000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(15000, monthlyPaySlip.GrossMonthlyIncome);
            Assert.AreEqual(3333.33, Math.Round(monthlyPaySlip.MonthlyIncomeTax, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(11666.67, Math.Round(monthlyPaySlip.NetMonthlyIncome, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReducesTaxWhenInTopTaxSlabTest()
        {
            // Arrange
            _employee.SetAnnualSalary(200000.0);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(16666.67, Math.Round(monthlyPaySlip.GrossMonthlyIncome, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(4000, Math.Round(monthlyPaySlip.MonthlyIncomeTax, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(12666.67, Math.Round(monthlyPaySlip.NetMonthlyIncome, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void EmployeesMonthlySalaryReducesTaxWhenInTopTaxSlab_AusTaxMethodTest()
        {
            // Arrange
            _employee.SetAnnualSalary(200000.0);
            _employee.SetAlgoirthm(TaxConstants.Algorithm.AusTax);

            // Act
            var monthlyPaySlip = _employee.GetMonthlyPaySlip();

            // Assert
            Assert.AreEqual(EmployeeName, monthlyPaySlip.Name);
            Assert.AreEqual(16666.67, Math.Round(monthlyPaySlip.GrossMonthlyIncome, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(4000, Math.Round(monthlyPaySlip.MonthlyIncomeTax, 2, MidpointRounding.AwayFromZero));
            Assert.AreEqual(12666.67, Math.Round(monthlyPaySlip.NetMonthlyIncome, 2, MidpointRounding.AwayFromZero));
        }
    }
}
