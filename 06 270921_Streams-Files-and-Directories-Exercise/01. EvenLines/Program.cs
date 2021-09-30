using System;
using System.IO;
using System.Linq;

namespace _01._EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"..\..\..\text.txt");
            string[] specialSymbol = new[] { "-", ",", ".", "!", "?" };

            bool isEven = true;

            while (true)
            {
                string result = streamReader.ReadLine();

                if (result == null)
                {
                    break;
                }

                if (!isEven)
                {
                    isEven = true;
                    continue;
                }

                foreach (var symbol in specialSymbol)
                {
                    result = result.Replace(symbol, "@");
                }

                Console.WriteLine(string.Join(" ", result.Split().Reverse()));
                isEven = false;
            }
        }
    }
}
