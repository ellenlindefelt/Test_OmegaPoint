using System;
namespace Test_OmegaPoint
{
    public interface IValidityChecker //Interface för att kunna använda alla tre numren i Verifier.
    {
        public bool checkFormat(string input, StringFormat stringFormat);
    }

}

