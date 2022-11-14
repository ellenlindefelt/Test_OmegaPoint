using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

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
            if (validFormat(input) == false)
            {
                Console.WriteLine($"Input: {input} failed SamNumFormatValidityCheck");
                return false;
            }

            return true;
        }

        // Checks if the date equals a real date + 60 //
        private bool validFormat(string input)
        {
            string temp = String.Concat(input.Where(x => Char.IsDigit(x)));
            int.TryParse(temp.Substring((temp.Length - 6),2), out int day);
            if (day < 61 || day > 91)
            {
                return false;
            }
            if (new DateChecker().IsValidDate(ConvertToDate(input)) == false)
            {
                return false;
            }
         
            return true;
        }

        private string ConvertToDate(string input)
        {
            string output = "";
            int length = input.Length;
            if (input.Length % 2 == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i == length - 6)
                    {
                        int.TryParse(input[i].ToString(), out int temp);
                        output += temp - 6;
                    }
                    else
                    {
                        output += input[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (i == length - 7)
                    {
                        int.TryParse(input[i].ToString(), out int temp);
                        output += temp - 6;
                    }
                    else
                    {
                        output += input[i];
                    }
                }
            }
            return output;
        }
    }
}
