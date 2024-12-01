using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    internal class Format
    {
        public static string formatPrice(decimal price)
        {
            return $"{price.ToString("N0")} đ";
        }

        public static decimal formatPrice_StrToDec(string price)
        {
            // Remove currency symbol and thousands separators
            string cleanPrice = price.Replace("đ", "").Replace(".", "");

            // Use a culture that understands the decimal separator (.) for parsing.
            // InvariantCulture is a good choice for this because it's not locale-specific.
            decimal decimalPrice;

            if (decimal.TryParse(cleanPrice, NumberStyles.Number, CultureInfo.InvariantCulture, out decimalPrice))
            {
                return decimalPrice;
            }
            else
            {
                // Handle parsing errors.  Throw an exception or return a default value.
                throw new FormatException("Invalid price format.");  // Or return 0M;
            }
        }
    }
}
