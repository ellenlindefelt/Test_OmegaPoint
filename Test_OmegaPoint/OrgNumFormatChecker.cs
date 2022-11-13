using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class OrgNumFormatChecker : IValidityChecker //Kontrollera specifikt format för Organisationsnummer.
    { 
        public OrgNumFormatChecker()
        {
        }

        //Checks if input follows the allowed format for Organisationsnummer.
        public bool validityCheck(string input)
        {
            if (validFormat(input) == false)
            {
                Console.WriteLine($"Input: {input} failed OrgNumFormatValidityCheck");
                return false;
            }
            return true;
        }

        private bool validFormat(string input)
        {
            input = String.Concat(input.Where(x => Char.IsDigit(x)));

            if (input.Length > 10)
            {
                var start = input.Substring(0, 2);
                if (start != "16")
                {
                    return false;
                }
            }

            int.TryParse(input.Substring(input.Length - 8, 2), out int middleDigits);
            if (middleDigits < 20)
            {
                return false;
            }
            return true;
        }
    }
}


