using System;
using System.Text.RegularExpressions;
using System.Globalization;
namespace Test_OmegaPoint
{
    public class SSNFormatChecker : IValidityChecker //Kontrollera specifikt format för Personnummer.
    {
        public SSNFormatChecker()
        {
        }

        //Checks if input follows the allowed format for Social Secutity Numbers.
        public bool validityCheck(string input)
        {

            if (CheckFormat(input) == false)
            {
                Console.WriteLine($"Input: {input} failed SSNFormatValidityCheck");
                return false;
            }
            return true;
        }


        private bool CheckFormat(string input)
        {

            input = String.Concat(input.Where(x => Char.IsDigit(x)));

            if (input.Length > 10)
            {
                var start = int.Parse(input.Substring(0, 4));
                if (start < 1800)
                {
                    return false;
                }
            }
            int.TryParse(input.Substring(input.Length - 6, 2), out int lastDigits);
            if (lastDigits < 1 || lastDigits > 31)
            {
                return false;
            }
            int.TryParse(input.Substring(input.Length - 8, 2), out int middleDigits);
            if (middleDigits < 1 || middleDigits > 12)
            {
                return false;
            }
            return true;
        }
    }
}

