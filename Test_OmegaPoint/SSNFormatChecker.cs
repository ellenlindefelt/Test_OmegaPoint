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
            
            if (new DateChecker().IsValidDate(input) == false)
            {
                Console.WriteLine($"Input: {input} failed SSNFormatValidityCheck");
                return false;
            }
            return true;
        }
    }
}

