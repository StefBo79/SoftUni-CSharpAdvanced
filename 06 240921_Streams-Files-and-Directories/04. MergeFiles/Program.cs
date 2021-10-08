using System;
using System.IO;

namespace _04._MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readOne = File.ReadAllText("inputOne.txt").Split();
            string[] readTwo = File.ReadAllText("inputTwo.txt").Split();

            File.WriteAllText("result.txt", "");

            for (int i = 0; i < readOne.Length; i++)
            {
                File.AppendAllText("result.txt", readOne[i] + "\r\n" + readTwo[i]);
            }
        }
    }
}
