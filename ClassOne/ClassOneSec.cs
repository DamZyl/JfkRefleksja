using JfkLab3Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOne
{
    public class ClassOneSec : IMyMethod
    {
        [Description("Metoda z klasy ClassOneSec. Przyjmująca argument wejściowy, który jest typu double, z które oblicza sinus podniesiony do potęgi 2 oraz dodaje cosinus podniesiony do potęgi 3 " +
                      "oraz odejmuje 2 od wyniku wcześniejszej operacji. Parametr x musi być z przedziału <-2PI, 2PI>")]
        public double Method(double x)
        {
            if (x < -2 * Math.PI || x > 2 * Math.PI)
            {
                return -1;
            }

            return (Math.Pow(Math.Sin(x), 2) + Math.Pow(Math.Cos(x), 3)) - 2; 
        }
    }
}
