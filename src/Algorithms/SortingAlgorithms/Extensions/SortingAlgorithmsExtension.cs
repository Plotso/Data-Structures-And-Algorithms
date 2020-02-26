﻿namespace Algorithms.SortingAlgorithms.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// A static class providing extension methods for using Searching Algorithms over IList
    /// </summary>
    public static class SortingAlgorithmsExtension
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
        
        private static bool ShouldSwap(int firstElement, int secondElement, SortOrder sortOrder) 
            => sortOrder == SortOrder.Ascending ?
                firstElement > secondElement :
                firstElement < secondElement;
    }
}