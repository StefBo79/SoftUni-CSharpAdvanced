using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allFiles = Directory.GetFiles(@"..\..\..", "*.*");

            Dictionary<string, Dictionary<string, double>> groupedFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!groupedFiles.ContainsKey(fileInfo.Extension))
                {
                    groupedFiles.Add(fileInfo.Extension, new Dictionary<string, double>());
                }

                double size = (double)fileInfo.Length / 1024;
                groupedFiles[fileInfo.Extension].Add(fileInfo.Name, size);
            }

            var sortedFiles = groupedFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            List<string> lines = new List<string>();

            foreach (var file in sortedFiles)
            {
                lines.Add(file.Key);

                foreach (var item in file.Value.OrderBy(x => x.Value))
                {
                    lines.Add($"--{item.Key} - {item.Value:F3}kb");
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllLines(path, lines);
        }
    }
}
