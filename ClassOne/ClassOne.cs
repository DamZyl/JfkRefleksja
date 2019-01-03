using JfkLab3Interface;

namespace ClassOne
{
    public class ClassOne : IMyMethods
    {
        [Description("Pierwsza metoda interfejsu IMyMethods w klasie ClassOne przyjmująca jeden parametr typu string, która sprawdza długość parametru i następnie w zależności od tego czy " +
                        "długość jest parzysta czy nie parzysta wykonuje operacje na parametrze w przypadku, gdy długość jest większa od 5 i jest to liczba parzysta funkcja tworzy nową zmienną typu string, " +
                        "która od początku do połowy ma duże litery, a od połowy do końca ma małe litery, jeżeli długość jest większa od 5 i jest to liczba nieparzysta funkcja dodaje do długości 1 aby długość" +
                        "była liczbą parzystą oraz wykonuje takie same operacje jak w pierwszym przypadku, jeżeli natomiast długość jest mniejsza lub równa 5 funkcja zwraca napis (Za krótki tekst w argumencie) pisany dużymi literami")]
        public string FirstMethod(string text)
        {
            int halfText;
            string result = null;

            if ((text.Length) > 5 && (text.Length & 1) == 0)
            {
                halfText = text.Length / 2;

                result = text.Substring(0, halfText).ToUpper() + text.Substring(halfText, text.Length - halfText).ToLower();
            }

            else if ((text.Length) > 5 && (text.Length & 1) != 0)
            {
                halfText = (text.Length + 1) / 2;

                result = text.Substring(0, halfText).ToUpper() + text.Substring(halfText, text.Length - halfText).ToLower();
            }

            else if (text.Length <= 5)
            {
                string tmp = "Za krótki tekst w argumencie";

                result = tmp.ToUpper();
            }

            return result;
        }

        [Description("Druga metoda interfejsu IMyMethods w klasie ClassOne przyjmująca jeden parametr typu string, dodaje do podanego parametru go samego tyle razy ile wynosi długość parametru")]
        public string SecondMethod(string text)
        {
            string result = null;

            for (int i = 0; i < text.Length; i++)
            {
                result += (" " + text);
            }

            return result;
        }
    }
}
