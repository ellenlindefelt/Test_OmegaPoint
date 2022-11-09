using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class OrgNumChecker : IValidityChecker //Kontrollera specifikt format för Organisationsnummer.
    { 
        public OrgNumChecker()
        {
        }

        public bool checkFormat(string input, StringFormat stringFormat)
        {
            if (stringFormat.checkFormat(input) == false)
            {
                Console.WriteLine("checkFormat2 failed");
                return false;
            }
            input = String.Concat(input.Where(x => Char.IsDigit(x)));

            if (input.Length > 10)
            {
                var start = input.Substring(0,2);
                if (start != "16") 
                {
                    Console.WriteLine("input start failed");
                    return false;
                }
            }
            
            int.TryParse(input.Substring(input.Length - 8, 2), out int sub);
            if (sub < 20)
                return false;

            Console.WriteLine("input is ok");
            return true;
        }
    }
}


