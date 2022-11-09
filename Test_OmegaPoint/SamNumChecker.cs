using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class SamNumChecker : IValidityChecker //Kontrollerar specifikt format för samordningsnummer.
    {
        public SamNumChecker()
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
                var start = int.Parse(input.Substring(0, 4));
                if (start < 1800)
                {
                    Console.WriteLine("input start failed");
                    return false;
                }
            }
            int.TryParse(input.Substring(input.Length - 6, 2), out int sub);
            if (sub < 61 || sub > 91)
            {
                Console.WriteLine("samnum failed");
                return false;
            }
            int.TryParse(input.Substring(input.Length - 8, 2), out sub);
            if (sub < 1 || sub > 12)
                return false;

            Console.WriteLine("input is ok");
            return true;
        }

    }
}
