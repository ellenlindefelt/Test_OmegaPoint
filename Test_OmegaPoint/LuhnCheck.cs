using System;
namespace Test_OmegaPoint
{
    public class LuhnCheck : IAlgorithm //Kontrollerar en list<int> med Luhn-algoritmen. 
    {
        public LuhnCheck()
        {
        }
        public bool RunAlgorithm(List<int> input)
        {
            var controlNumber = input.Last();
            input.RemoveAt(input.Count - 1);


            for (int i = 0; i < input.Count; i++)
            {

                if (i % 2 == 0)
                {
                    input[i] *= 2;

                    if (input[i] >= 10)
                    {
                        input[i] = input[i] - 10 + 1;

                    }
                }
            }

            int result = (10 - (input.Sum() % 10) % 10);
            if (result % 10 == 0)
            {
                result = 0;
            }
            if (controlNumber == result)
            {
                Console.WriteLine("Luhn successful");
                return true;
            }
            Console.WriteLine("Luhn failed");

            return false;
        }
    }
}

