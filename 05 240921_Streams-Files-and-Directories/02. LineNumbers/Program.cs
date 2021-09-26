using System;
using System.IO;

namespace _02._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("data_input.txt");
            using StreamWriter sw = new StreamWriter("data_output1.txt");

            int counter = 1;

            string line = sr.ReadLine();

            while (line != null)
            {
                sw.WriteLine($"{counter}. {line}");

                line = sr.ReadLine();
                counter++;
            }
        }
    }
}
