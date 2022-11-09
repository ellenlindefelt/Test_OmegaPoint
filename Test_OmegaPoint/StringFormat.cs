using System;
using System.Text.RegularExpressions;

namespace Test_OmegaPoint
{
    public class StringFormat // Jämför string med regular expressions för att kontrollera format.
                              // Samma för alla olika numren.
    { 
        public StringFormat()
        {
        }
        public bool checkFormat(string input)
        {
            string format1 = @"(^[0-9]{12}$)";
            string format2 = @"(^[0-9]{6}[-+]?[0-9]{4}$)";
            string format3 = @"(^[0-9]{8}\-[0-9]{4}$)";
            Regex regex = new Regex(format1);


            if (regex.IsMatch(input))
            {
                Console.WriteLine("format1 is ok!");
                return true;
            }
            regex = new Regex(format2);

            if (regex.IsMatch(input))
            {
                Console.WriteLine("format2 is ok!");
                return true;
            }
            regex = new Regex(format3);
            if (regex.IsMatch(input))
            {
                Console.WriteLine("format3 is ok!");
                return true;
            }
            Console.WriteLine("Wrong format");
            return false;
        }
    }
}

