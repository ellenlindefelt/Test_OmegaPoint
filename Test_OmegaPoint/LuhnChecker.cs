using System;
namespace Test_OmegaPoint
{
    public class LuhnChecker : IValidityChecker
    {
        public LuhnChecker()
        {
        }

        //Uses Luhn Algorithm and compares to the check digit.
        public bool validityCheck(string input)
        {
         
            List<int> inputAsList = new Converter().Convert(input);
            int checkDigit = inputAsList.Last();
            inputAsList.RemoveAt(inputAsList.Count - 1);


            for (int i = 0; i < inputAsList.Count; i++)
            {

                if (i % 2 == 0)
                {
                    inputAsList[i] *= 2;

                    if (inputAsList[i] >= 10)
                    {
                        inputAsList[i] = inputAsList[i] - 10 + 1;

                    }
                }
            }

            int result = (10 - (inputAsList.Sum() % 10) % 10);
            if (result % 10 == 0)
            {
                result = 0;
            }
            if (checkDigit == result)
            {
                return true;
            }
            return false;
        }
    }
}

