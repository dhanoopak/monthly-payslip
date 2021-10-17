using System;

namespace GenerateMonthlyPayslip
{
    /// <summary>
    /// Included generic extension methods 
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Extension method to print a double value in string format with a currency prefix
        /// </summary>
        /// <param name="inputCurrency">input double value</param>
        /// <param name="currencySign">Currency sign. Default value is '$'</param>
        /// <returns>Currency string</returns>
        public static string ToCurrency(this double inputCurrency, string currencySign = "$")
        {
            inputCurrency = Math.Round(inputCurrency, 2, MidpointRounding.AwayFromZero);

            return $"{((inputCurrency < 0) ? "-" : string.Empty)}{currencySign}{Math.Abs(inputCurrency)}";
        }
    }
}
