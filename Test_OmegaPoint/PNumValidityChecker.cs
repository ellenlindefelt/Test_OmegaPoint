using System;
using System.Text.RegularExpressions;
using System.Globalization;
namespace Test_OmegaPoint
{
    public class PNumValidityChecker : IValidityChecker //Kontrollera specifikt format för Personnummer.
    {
        public PNumValidityChecker()
        {
        }


        public bool checkFormat(string input, StringFormat stringFormat)
        {
            if (stringFormat.checkFormat(input) == false)
            {
                Console.WriteLine("checkFormat2 failed");
                return false;
            }
            if (input.Length > 11)
            {
                var start = input.Substring(0, 2);
                if (start != "18" && start != "19" && start != "20")
                {
                    Console.WriteLine("input start failed");
                    return false;
                }
            }
            Console.WriteLine("input is ok");
            return true;
        }


        public bool CheckDateForm(string input)
        {
           
            bool dateformat = DateTime.TryParseExact(input, "yymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
            if (dateformat == true)
            {
                return true;
            }
           
            dateformat = DateTime.TryParseExact(input, "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if(dateformat == true)
            {
                return date.Year > 1800;
            }

            return false;
        }

    }
}

