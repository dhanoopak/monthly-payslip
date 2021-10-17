using GenerateMonthlyPayslip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonthlyPayslipTest
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void CurrencyExtensionMethodReturnsZeroDollarWhenInputIsZeroTest()
        {
            // Arrange
            double input = 0;

            // Act
            var output = input.ToCurrency();

            // Assert
            Assert.AreEqual( "$0", output);
        }

        [TestMethod]
        public void CurrencyMethodReturnsNegativeCurrencyValueWhenPassedWithNegativeInputTest()
        {
            // Arrange
            double input = -10;

            // -$10
            // $-10 ==> -$

            // Act
            var output = input.ToCurrency();

            // Assert
            Assert.AreEqual("-$10", output);
        }

        [TestMethod]
        public void CurrencyMethodReturnsThousandDollarWhenPassedWith1000AsInput()
        {
            // Arrange
            double input = 1000;

            // Act
            var output = input.ToCurrency();

            // Assert
            Assert.AreEqual("$1000", output);
        }

        [TestMethod]
        public void CurrencyMethodReturnsThousandEuroWhenPassedWith1000AsInput()
        {
            // Arrange
            double input = 1000;

            // Act
            var output = input.ToCurrency("€");

            // Assert
            Assert.AreEqual("€1000", output);
        }
    }
}
