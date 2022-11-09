using System;
namespace Test_OmegaPoint
{
    public interface IAlgorithm //Interface för att kunna använda vilken algoritm som helst i Verifier.
    {
        public bool RunAlgorithm(List<int> input);
    }
}

