namespace Algorithms.SortingAlgorithms.Simple.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// A static class providing extension methods for using Searching Algorithms over IList
    /// </summary>
    public static class SimpleSortingAlgorithmsExtensions
    {
        /// <summary>
        /// Sort collection using BubbleSort algorithm. It has complexity O(n*n)
        /// </summary>
        /// <param name="list">Collection that should be sorted</param>
        /// <param name="sortOrder">Determines whether algorithm should sort collection in ascending or descending order</param>
        public static IList<int> BubbleSort(this IList<int> list, SortOrder sortOrder = SortOrder.Ascending)
        {
            var n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                var swappedElement = false;
                
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ShouldSwap(list[j], list[j+1], sortOrder))
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swappedElement = true;
                    }
                }

                if (!swappedElement)
                {
                    break;
                }
            }

            return list;
        }
        
        /// <summary>
        /// Sort collection using SelectionSort algorithm. It has complexity O(n*n)
        /// </summary>
        public static void SelectionSort(this IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var min = i;
                for (int current = i + 1; current < list.Count; current++)
                {
                    if (list[current] < list[min])
                    {
                        min = current;
                    }
                }
                list.Swap(i, min);
            }
        }
        
        /// <summary>
        /// Sort collection using InsertionSort algorithm. It has complexity O(n*n)
        /// </summary>
        /// <param name="list"></param>
        public static void InsertionSort(this IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                var key = list[i];
                var current = i - 1;

                // move elements greater than key to one position ahead
                while (current >= 0 && list[current] > key)
                {
                    list[current + 1] = list[current];
                    current--;
                }

                list[current + 1] = key;
            }
        }
        
        private static bool ShouldSwap(int firstElement, int secondElement, SortOrder sortOrder) 
            => sortOrder == SortOrder.Ascending ?
                firstElement > secondElement :
                firstElement < secondElement;
    }
}