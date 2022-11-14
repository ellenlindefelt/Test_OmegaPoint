using System;
namespace Test_OmegaPoint
{
    public class Converter : IConverter<string,List<int>> 
    {
        public Converter()
        {
        }

        //Convert a string to list of ints (used in LuhnChecker.validityCheck)
        public List<int> Convert(string input)
        {
            input = String.Concat(input.Where(x => Char.IsDigit(x)).ToList());

            var output = new List<int>();
            foreach (var c in input)
            {
                output.Add(int.Parse(c.ToString()));
            }
            if (output.Count > 10)
            {
                output.RemoveRange(0, 2);
            }
            return output;
        }
    }
}

