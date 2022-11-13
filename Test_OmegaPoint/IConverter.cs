using System;
namespace Test_OmegaPoint
{
    public interface IConverter<T1,T2>
    {
        public T2 Convert(T1 input); 
    }
}

