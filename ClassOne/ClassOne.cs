using JfkLab3Interface;
using System;

namespace ClassOne
{
    public class ClassOne : IMyMethod
    {
        [Description("Metoda z klasy ClassOne. Przyjmująca argument wejściowy, który jest typu double, następnie wykonująca operacje podniesienia argumentu do potęgi 3 " +
                     "oraz wykonania operaci podłogi na wyniku wcześniejszej operacji. Parametr x musi być z przedziału <-20, 20>")]
        public double Method(double x)
        {
            if (x < -20 || x > 20)
            {
                return -1;
            }

            return Math.Floor(Math.Pow(x, 3));
        }
    }
}
