using JfkLab3Interface;
using System.Linq;

namespace ClassTwo
{
    public class ClassTwo : IMyMethods
    {
        [Description("Pierwsza metoda interfejsu IMyMethods w klasie ClassTwo przyjmująca jeden parametr typu string, która sprawdza długość parametru i następnie w zależności od tego czy " +
                        "długość jest parzysta czy nie parzysta wykonuje operacje na parametrze w przypadku, gdy długość jest większa od 5 i jest to liczba parzysta funkcja tworzy nową zmienną typu string, " +
                        "która od początku do połowy ma małe litery, a od połowy do końca ma duże litery, jeżeli długość jest większa od 5 i jest to liczba nieparzysta funkcja dodaje do długości 1 aby długość" +
                        "była liczbą parzystą oraz wykonuje takie same operacje jak w pierwszym przypadku, jeżeli natomiast długość jest mniejsza lub równa 5 funkcja zwraca napis (Za krótki tekst w argumencie) pisany małymi literami")]
        public string FirstMethod(string text)
        {
            int halfText;
            string result = null;

            if ((text.Length) > 5 && (text.Length & 1) == 0)
            {
                halfText = text.Length / 2;

                result = text.Substring(0, halfText).ToLower() + text.Substring(halfText, text.Length - halfText).ToUpper();
            }

            else if ((text.Length) > 5 && (text.Length & 1) != 0)
            {
                halfText = (text.Length + 1) / 2;

                result = text.Substring(0, halfText).ToLower() + text.Substring(halfText, text.Length - halfText).ToUpper();
            }

            else if (text.Length <= 5)
            {
                string tmp = "Za krótki tekst w argumencie";

                result = tmp.ToLower();
            }

            return result;
        }

        [Description("Druga metoda interfejsu IMyMethods w klasie ClassTwo przyjmująca jeden parametr typu string, która odwraca podany parametr i go zwraca jako string")]
        public string SecondMethod(string text)
        {
            var tmpText = text.Reverse().ToArray();

            string result = new string(tmpText);

            return result;
        }
    }
}
