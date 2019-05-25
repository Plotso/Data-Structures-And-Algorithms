namespace ConsoleHost
{
    using Algorithms.SearchingAlgorithms.Extensions;
    using Algorithms.SearchingAlgorithms.InputBased;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The project responsible for hosting various algorithms and playgrounds displayed on the console!
    /// </summary>
    public class ConsoleHost
    {
        public static void Main(string[] args)
        {
            var list = new List<int> { 11, 22, 33, 44, 55 };
            var searchedItem = 55;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine($"The index of {searchedItem} is {list.LinearSearch(searchedItem)}");
            sw.Stop();
            Console.WriteLine($"The extension method took {sw.ElapsedMilliseconds}ms to execute");
            sw.Reset();

            sw.Start();
            var input = new SearchingAlgorithmInput(list, searchedItem);
            var searched = new LinearSearcher();
            Console.WriteLine($"The index of {searchedItem} is {searched.LinearSearch(input)}");
            sw.Stop();
            Console.WriteLine($"The input based approach took {sw.ElapsedMilliseconds}ms to execute");

            Console.WriteLine("The input based approach should be faster for this test");
        }
    }
}
