using System;
using System.IO.Compression;

namespace _06._ZipАndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"..\..\..\sourceDirectory";
            string resultZip = @"..\..\..\targetDirectory\result.zip";
            string targetDirectory = @"..\..\..\targetDirectory";

            ZipFile.CreateFromDirectory(sourceDirectory, resultZip);
            ZipFile.ExtractToDirectory(resultZip, targetDirectory);


        }
    }
}
