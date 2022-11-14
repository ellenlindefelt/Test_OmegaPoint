using System;
namespace Test_OmegaPoint
{
    public class DateChecker
    {
        public DateChecker()
        {
        }
        
        /*Checks if date is valid, keeping track of leapyears. 
         Used by SSNFormatChecker & SamNumFormatChecker. */
        public bool IsValidDate(string input)
        {
            bool isLeapYear = IsLeapYear(input);
            input = String.Concat(input.Where(x => Char.IsDigit(x)));

            if (input.Length > 10)
            {
                var year = int.Parse(input.Substring(0, 4));
                if (year < 1800)
                {
                    return false;
                }
            }
            if (input.Length == 10)
            {

            }
            int.TryParse(input.Substring(input.Length - 6, 2), out int day);
            if (day < 1 || day > 31)
            {
                return false;
            }
            int.TryParse(input.Substring(input.Length - 8, 2), out int month);
            if (month < 1 || month > 12)
            {
                return false;
            }
            if (isLeapYear == false && month == 2 && day > 28)
            {
                return false;
            }
            return true;
        }

        private bool IsLeapYear(string input)
        {
            int year = 1;
            if (input.Length > 11)
            {
                int.TryParse(input.Substring(0, 4), out year);
            }
            else if (input.Contains('+'))
            {
                int currentYear = DateTime.Now.Year;
                int.TryParse(input.Substring(0, 2), out year);
                if (currentYear % 1000 < year)
                {
                    year += 1800;
                }
                else
                {
                    year += 1900;
                }
            }
            if (DateTime.IsLeapYear(year))
            {
                return true;
            }
            return false;
        }
    }
}

