using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] wordLines = File.ReadAllLines(@"..\..\..\words.txt");
            string[] textLines = File.ReadAllLines(@"..\..\..\text.txt");

            foreach (var item in wordLines)
            {
                wordCount.Add(item, 0);

            }

            foreach (var line in textLines)
            {
                foreach (var word in wordCount)
                {
                    if (line.Contains(word.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        wordCount[word.Key]++;
                    }
                }
            }

            foreach (var item in wordCount.OrderByDescending(x => x.Value))
            {
                string result = $"{item.Key} - {item.Value}{Environment.NewLine}";
                File.AppendAllText(@"..\..\..\actualResult.txt", result);
            }
        }
    }
}
