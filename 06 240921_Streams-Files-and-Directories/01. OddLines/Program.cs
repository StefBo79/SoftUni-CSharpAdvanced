using System;
using System.IO;

namespace _01._OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("data_input.txt");
            using StreamWriter sw = new StreamWriter("data_output.txt");

            int counter = 0;

            string line = sr.ReadLine();

            while (line != null)
            {
                if (counter % 2 == 1)
                {
                    sw.WriteLine(line);
                }

                counter++;
                line = sr.ReadLine();
            }
        }
    }
}
