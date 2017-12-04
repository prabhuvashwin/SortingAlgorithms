using Sorting.Interfaces;
using Sorting.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
    class Program
    {
        static int[] randomArray, sortedArray, reverseSortedArray;

        static void Main(string[] args)
        {
            int count = 30000;

            randomArray = GetRandomArray(count);
            sortedArray = GetSortedArray(count);
            reverseSortedArray = GetReverseSortedArray(count);

            Execute();

            Console.ReadLine();
        }

        private static void Execute()
        {
            ISorter<int>[] algorithms = new ISorter<int>[]
            {
                new BubbleSort<int>(),
                new InsertionSort<int>(),
                new SelectionSort<int>(),
                new MergeSort<int>(),
                new QuickSort<int>()
            };

            foreach (ISorter<int> algorithm in algorithms)
            {
                RunAlgorithm(randomArray, algorithm, "Random data");
                algorithm.Reset();
                RunAlgorithm(sortedArray, algorithm, "Sorted data");
                algorithm.Reset();
                RunAlgorithm(reverseSortedArray, algorithm, "Reverse sorted data");
                algorithm.Reset();
            }
        }

        private static void RunAlgorithm(int[] array, ISorter<int> algorithm, string name)
        {
            int[] cloned = new int[array.Length];
            Array.Copy(array, cloned, array.Length);

            Console.WriteLine("Running algorithm: {0}", algorithm.GetType().Name);
            Console.WriteLine("Running data: {0}", name);
            Stopwatch sw = Stopwatch.StartNew();

            algorithm.Sort(cloned);

            sw.Stop();

            Console.WriteLine("Time take for execution: {0} seconds.", sw.ElapsedMilliseconds / 1000);
            Console.WriteLine("Number of comparisons: {0}", algorithm.Comparisons);
            Console.WriteLine("Number of swaps: {0}", algorithm.Swaps);

            Console.WriteLine(Environment.NewLine);
        }

        private static int[] GetReverseSortedArray(int count)
        {
            int[] array = new int[count];

            int current = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                array[current++] = i;
            }

            return array;
        }

        private static int[] GetSortedArray(int count)
        {
            int[] array = new int[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = i;
            }

            return array;
        }

        private static int[] GetRandomArray(int count)
        {
            Random r = new Random();
            int[] array = new int[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = r.Next();
            }

            return array;
        }
    }
}
