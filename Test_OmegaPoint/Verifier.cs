using System;
namespace Test_OmegaPoint
{
    public class Verifier
    {
        IValidityChecker specificFormatChecker;
        NullorEmptyChecker nullChecker;
        StringPatternChecker stringPatternChecker;
        LuhnChecker luhnChecker;
        public Verifier(IValidityChecker specificFormatChecker, NullorEmptyChecker nullChecker, StringPatternChecker stringPatternChecker, LuhnChecker luhnChecker)
        {
            this.specificFormatChecker = specificFormatChecker;
            this.nullChecker = nullChecker;
            this.luhnChecker = luhnChecker;
            this.stringPatternChecker = stringPatternChecker;
        }

        /* Method that performs all the validity checks. If input fails validity
        check method logs to console and returns false immediately. */
        public bool Verify(string input)
        {
            if (nullChecker.validityCheck(input) == false)
            {
                Console.WriteLine($"Input failed NullorEmptyCheck");
                return false;
            }
            if (stringPatternChecker.validityCheck(input) == false)
            {
                Console.WriteLine($"Input: {input} failed StringFormatCheck");
                return false;
            }
            if (specificFormatChecker.validityCheck(input) == false)
            {
                return false;
            }
            if (luhnChecker.validityCheck(input) == false)
            {
                Console.WriteLine($"Input: {input} failed LuhnCheck");
                return false;
            }
            return true;
        }
    }
}

