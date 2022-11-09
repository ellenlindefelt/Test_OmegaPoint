using System;
namespace Test_OmegaPoint
{
    public interface IConverter<T1,T2> //Interface för konvertering av input till en annan typ av output.
                                        //Används för att göra en string till en list<int>.
    {
        public T2 Convert(T1 input); 
    }
}

