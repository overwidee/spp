using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace example4
{
    class Program
    {
        //В файле содержится текстовая строка. Определить частоту повторяемости каждой буквы в тексте и вывести ее.
        private static async Task Main(string[] args)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\textDoc.txt";
            Console.WriteLine($"Path to file - {filePath}");

            var chars = (await File.ReadAllTextAsync(filePath)).ToList();

            var existChar = new List<char>();
            chars.ForEach(c =>
            {
                var count = chars.Count(x => x == c);

                if (existChar.Contains(c)) return;
                
                Console.WriteLine($"{c} - {new string('*', count)} ({count})");
                existChar.Add(c);
            });

            Console.ReadKey();
        }
    }
}