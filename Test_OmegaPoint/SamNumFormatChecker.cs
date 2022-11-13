using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class SamNumFormatChecker : IValidityChecker //Kontrollerar specifikt format för samordningsnummer.
    {
        public SamNumFormatChecker()
        {
        }

        //Checks if input follows the allowed format for Samordningsnummer.
        public bool validityCheck(string input)
        {
            if(validFormat(input) == false)
            {
                Console.WriteLine($"Input: {input} failed SamNumFormatValidityCheck");
                return false;
            }

            return true;
        }
        private bool validFormat(string input)
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
            if (lastDigits < 61 || lastDigits > 91)
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
