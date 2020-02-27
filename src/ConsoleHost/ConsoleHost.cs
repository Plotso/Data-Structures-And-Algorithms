namespace ConsoleHost
{
    using Algorithms.SearchingAlgorithms.Extensions;
    using Algorithms.SearchingAlgorithms.InputBased;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Algorithms.SortingAlgorithms;
    using Algorithms.SortingAlgorithms.Extensions;
    using DataStructures.Trees;

    /// <summary>
    /// The project responsible for hosting various algorithms and playgrounds displayed on the console!
    /// </summary>
    public class ConsoleHost
    {
        private const string LinearSearchAlgorithm = "LinearSearch Algorithm";
        private const string BinarySearchAlgorithm = "BinarySearch Algorithm";

        public static void Main(string[] args)
        {
            var list = new List<int> { 11, 22, 33, 44, 55, 77, 66 };
            var searchedItem = 55;

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("SEARCHING ALGORITHMS");
            Console.WriteLine(new string('=', 50));
            
            LinearSearchPlayground(list, searchedItem);
            BinarySearchPlayground(list, searchedItem);
            
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("SORTING ALGORITHMS");
            Console.WriteLine(new string('=', 50));
            
            BubbleSortPlayground(list);
            
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("DATASTRUCTURES");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("BinarySearchTree");
            Console.WriteLine(new string('=', 50));
            BinarySearchTreePlayground();
        }

        private static void BubbleSortPlayground(List<int> list)
        {
            var listToSort = list;
            var bubleSortAlgorithm = new BubbleSortAlgorithm();

            bubleSortAlgorithm.Sort(listToSort);
            Console.WriteLine($"BubbleSort list in ascending: " + StringifyList(listToSort));

            bubleSortAlgorithm.Sort(listToSort, SortOrder.Descending);
            Console.WriteLine($"BubbleSort list descending: " + StringifyList(listToSort));

            Console.WriteLine($"BubbleSort list ascending with extension: " + StringifyList(listToSort.BubbleSort()));
        }

        private static void LinearSearchPlayground(IList<int> list, int searchedItem)
        {
            Console.WriteLine(GenerateSearchingAlgorithmMessage(LinearSearchAlgorithm, list, searchedItem));

            Stopwatch sw = new Stopwatch();

            sw.Start();
            Console.WriteLine($">The index of {searchedItem} is {list.LinearSearch(searchedItem)}");
            sw.Stop();
            Console.WriteLine($">The extension method took {sw.ElapsedMilliseconds}ms to execute");
            sw.Reset();

            sw.Start();
            var input = new SearchingAlgorithmInput(list, searchedItem);
            var searched = new LinearSearchAlgorithm();
            Console.WriteLine($">The index of {searchedItem} is {searched.LinearSearch(input)}");
            sw.Stop();
            Console.WriteLine($">The input based approach took {sw.ElapsedMilliseconds}ms to execute");

            Console.WriteLine("---The input based approach should be faster for this test");
        }

        private static void BinarySearchPlayground(IList<int> list, int searchedItem)
        {
            Console.WriteLine(GenerateSearchingAlgorithmMessage(BinarySearchAlgorithm, list, searchedItem));

            if (!IsSortedAscending(list))
            {
                list = list.OrderBy(x => x).ToList();
                Console.WriteLine($"{BinarySearchAlgorithm} requires sorted collection to behave correctly." +
                    $" Therefore, we will re-order the list: {StringifyList(list)}");
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine($">The index of {searchedItem} is {list.BinarySearch(searchedItem)}");
            sw.Stop();
            Console.WriteLine($">The extension method took {sw.ElapsedMilliseconds}ms to execute iteratively");
            sw.Reset();

            var input = new SearchingAlgorithmInput(list, searchedItem);
            var searched = new BinarySearchAlgorithm();

            sw.Start();
            Console.WriteLine($">The index of {searchedItem} is {searched.BinarySearch(input, true)}");
            sw.Stop();
            Console.WriteLine($">The input based approach took {sw.ElapsedMilliseconds}ms to execute recursively");

            sw.Start();
            Console.WriteLine($">The index of {searchedItem} is {searched.BinarySearch(input)}");
            sw.Stop();
            Console.WriteLine($">The input based approach took {sw.ElapsedMilliseconds}ms to execute iteratively");

            Console.WriteLine("---The input based approach should be faster for this test");
        }

        private static void BinarySearchTreePlayground()
        {
            var tree = new BinarySearchTree();
            
            InsertData(tree);
            
            var inorderSort = tree.DisplayTree();
            var preorderSort = tree.DisplayTree(TraversalType.Preorder);
            var postorderSort = tree.DisplayTree(TraversalType.Postorder);
            Console.WriteLine($"Root: {tree.GetRoot().Data}");
            Console.WriteLine($"Inorder: {inorderSort}");
            Console.WriteLine($"Preorder: {preorderSort}");
            Console.WriteLine($"Postorder: {postorderSort}");
        }
        
        private static void InsertData(BinarySearchTree tree)
        {
            tree.Insert(30);
            tree.Insert(35);
            tree.Insert(57);
            tree.Insert(15);
            tree.Insert(63);
            tree.Insert(49);
            tree.Insert(89);
            tree.Insert(77);
            tree.Insert(67);
            tree.Insert(98);
            tree.Insert(91);
        }

        private static bool IsSortedAscending(IList<int> list)
        {
            bool isAscending = true;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] > list[i])
                {
                    isAscending = false;
                }
            }

            return isAscending;
        }

        private static string GenerateSearchingAlgorithmMessage(
            string algorithmName,
            IList<int> list,
            int searchedItem) =>
            $"Using {algorithmName} to find {searchedItem} in {StringifyList(list)}";

        private static string StringifyList(IList<int> list) =>
            $"[{string.Join(" ,", list)}]";
    }
}
