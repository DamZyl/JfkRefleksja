using JfkLab3Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTwo
{
    public class ClassTwoSec : IMyMethod
    {
        [Description("Metoda z klasy ClassTwoSec. Przyjmująca argument wejściowy, który jest typu double, następnie zwracająca wartość na podstawie wzoru na pole sześciokąta foremnego gdzie x jest bokiem. Parametr x musi być > 0 i x < 1000")]
        public double Method(double x)
        {
            if (x < 0 || x >= 1000)
            {
                return -1;
            }

            return ((3 * Math.Pow(x, 2) * Math.Sqrt(3)) / 2);
        }
    }
}
