using System;
using System.Collections;

namespace example3
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgorithmGraph.N = 5;
            const int inf = (int.MaxValue / 2) - 1;
            var mas = new[,]
            {
                {0, 1, inf, inf, inf},
                {inf, 0, 1, 3, inf},
                {inf, inf, 0, 1, 6},
                {8, inf, inf, 0, 3},
                {inf, inf, inf, inf, 0},
            };

            AlgorithmGraph.FloydWarshall(ref mas);

            Console.WriteLine("Алгоритм Флойда : ");
            for (var i = 0; i < AlgorithmGraph.N; i++)
            {
                for (var j = 0; j < AlgorithmGraph.N; j++)
                    Console.Write(mas[i, j] + "\t");
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.ReadKey();
        }

        private class AlgorithmGraph
        {
            public static int N = 4;

            public static void FloydWarshall(ref int[,] mas)
            {
                for (var k = 0; k < N - 1; k++)
                {
                    for (var i = 0; i < N - 1; i++)
                    {
                        for (var j = 0; j < N - 1; j++)
                        {
                            mas[i, j] = Min(mas[i, k], mas[i, k] + mas[k, j]);
                        }
                    }
                }
            }

            private static T Min<T>(T first, T second) where T : IComparable
            {
                return first.CompareTo(second) < 0 ? first : second;
            }
        }
    }
}