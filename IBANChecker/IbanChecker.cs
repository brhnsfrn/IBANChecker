using System.Globalization;
using System.Linq;
using System.Numerics;

namespace IBANChecker
{
    public class IbanChecker
    {
        private string iban;

        /// <summary>
        /// The International Bank Account Number (IBAN) Checker with Modulo 97 Algorithm 
        /// </summary>
        /// <param name="iban"></param>
        public IbanChecker(string iban)
        {
            this.iban = iban.Trim().Replace(" ", "");
        }

        public bool IsValid()
        {
            iban = iban.Substring(4) + iban.Substring(0, 4); // Move first four to the end
            string number = string.Join(string.Empty, iban.Select(x => char.IsDigit(x) ? char.GetNumericValue(x).ToString(CultureInfo.InvariantCulture) : (x - 55).ToString())); // Replace characters with digits
            return BigInteger.Parse(number) % 97 == 1; // Calculate d = N mod 97 If d == 1 then valid, otherwise invalid.
        }
    }
}
