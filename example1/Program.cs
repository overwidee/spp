using System;
using System.Collections.Generic;
using System.Linq;

namespace example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var list = word?.ToList() ?? new List<char>();
            var oldReplace = new[] {'J', 'u', 'n', 'i', 'o', 'r'};
            var newReplace = new[] {'S', 'e', 'n', 'i', 'o', 'r'};

            var count = 0;
            var buf = new List<Tuple<int, char>>();
            var indexes = new List<Tuple<int, char>>();
            for (var i = 0; i < list.Count; i++)
            {
                if (count < 6 && list[i] == oldReplace[count])
                {
                    buf.Add(new Tuple<int, char>(i, newReplace[count]));
                    count++;
                }
                else if (count == 6)
                {
                    indexes.AddRange(buf);
                    buf.Clear();
                    count++;
                }
                else
                {
                    count = 0;
                    buf.Clear();
                }
            }

            for (var i = 0; i < indexes.Count; i++)
            {
                list[indexes[i].Item1] = indexes[i].Item2;
            }
            
            Console.WriteLine(new string(list.ToArray()));
            Console.ReadKey();
        }
    }
}