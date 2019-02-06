using JfkLab3Interface;
using System;
using System.Linq;

namespace ClassTwo
{
    public class ClassTwo : IMyMethod
    {
        [Description("Metoda z klasy ClassTwoSec. Przyjmująca argument wejściowy, który jest typu double, następnie zwracająca wartość na podstawie wzoru na pole koła, w którym x jest promieniem. Parametr x musi być > 0 i x < 1000")]
        public double Method(double x)
        {
            if (x < 0 || x >= 1000)
            {
                return -1;
            }

            return Math.PI * Math.Pow(x, 2);
        }
    }
}
