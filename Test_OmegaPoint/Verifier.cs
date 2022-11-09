using System;
namespace Test_OmegaPoint
{
    public class Verifier //Själva verifieringsklassen oavsett typ av nummer.
    {
        IValidityChecker validityChecker;
        IAlgorithm algorithm;
        StringFormat stringFormat;
        IConverter<string, List<int>> converter;
        public Verifier(IValidityChecker validityChecker, IAlgorithm algorithm, StringFormat stringFormat, IConverter<string, List<int>> converter)
        {
            this.validityChecker = validityChecker;
            this.algorithm = algorithm;
            this.stringFormat = stringFormat;
            this.converter = converter;
        }

        public bool Verify(string input)
        {
            bool isValid;
            if (validityChecker.checkFormat(input, stringFormat) == true)
            {
                isValid = algorithm.RunAlgorithm(converter.Convert(input));
            }
            else
                isValid = false;
            return isValid;
        }

    }
}

