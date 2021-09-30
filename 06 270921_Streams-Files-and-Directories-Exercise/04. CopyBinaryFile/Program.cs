using System;
using System.IO;

namespace _04._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileReader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open);
            using FileStream fileWriter = new FileStream(@"..\..\..\copyMeCopy.png", FileMode.Create);

            byte[] arrayOfBytes = new byte[256];

            while (true)
            {
                int currentBytes = fileReader.Read(arrayOfBytes, 0, arrayOfBytes.Length);

                if (currentBytes == 0 )
                {
                    break;
                }

                fileWriter.Write(arrayOfBytes, 0, arrayOfBytes.Length);
            }

            Console.WriteLine("Done");

        }
    }
}
