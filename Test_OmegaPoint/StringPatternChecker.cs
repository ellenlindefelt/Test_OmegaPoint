using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class StringPatternChecker : IValidityChecker
                                               
    { 
        public StringPatternChecker()
        {
        }

        /*Checks if input follows the allowed format for SSN/Samordningsnummer/
        Organisationsnummer using regular expressions to match string against
        a set of defined patterns.*/

        public bool validityCheck(string input)
        {   
            string format1 = @"(^[0-9]{12}$)";
            string format2 = @"(^[0-9]{6}[-+]?[0-9]{4}$)";
            string format3 = @"(^[0-9]{8}\-[0-9]{4}$)";
            Regex regex = new Regex(format1);


            if (regex.IsMatch(input))
            {

                return true;
            }
            regex = new Regex(format2);

            if (regex.IsMatch(input))
            {

                return true;
            }
            regex = new Regex(format3);
            if (regex.IsMatch(input))
            {

                return true;
            }

            return false;
        }
    }
}

