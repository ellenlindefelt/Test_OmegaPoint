using System;
namespace Test_OmegaPoint
{
    public class NullorEmptyChecker : IValidityChecker
    {
        public NullorEmptyChecker()
        {
        }

        //Checks if input is null or empty.
        public bool validityCheck(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }
    }
}

