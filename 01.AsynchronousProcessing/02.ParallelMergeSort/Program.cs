using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _02.ParallelMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Trim().Split().ToList();
            List<int> numbers = input.Select(int.Parse).ToList();
            Stopwatch stopwatch = new();

            stopwatch.Start();
            MergeSort mergeSort = new();
            Console.WriteLine(mergeSort.SortAndPrint(numbers));
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");
            stopwatch.Reset();

            stopwatch.Start();
            AsynchronousMergeSort asynchronousMergeSort = new();
            Console.WriteLine(asynchronousMergeSort.SortAndPrint(numbers));
            stopwatch.Stop();
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");
            stopwatch.Reset();
        }
    }
}
