using System;
using System.IO;

namespace _06._FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\bonev\source\repos\240921_Streams-Files-and-Directories\05. SliceАFile\bin\Debug\net5.0";
            string[] files = Directory.GetFiles(directoryPath);

            long totalLength = 0;

            foreach (var file in files)
            {
                totalLength += new FileInfo(file).Length;
            }

            Console.WriteLine(totalLength);
        }
    }
}
