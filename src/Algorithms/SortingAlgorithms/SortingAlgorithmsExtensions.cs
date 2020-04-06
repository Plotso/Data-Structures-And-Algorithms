namespace Algorithms.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using Simple;

    public static class SortingAlgorithmsExtensions
    {
        public static void Swap<T>(this IList<T> collection, int fromIndex, int toIndex)
        {
            var temp = collection[fromIndex];
            collection[fromIndex] = collection[toIndex];
            collection[toIndex] = temp;
        }

        public static bool ShouldSwap(IComparable first, IComparable second, SortOrder sortOrder = SortOrder.Ascending)
        {
            var comparisonResult = first.CompareTo(second);
            return sortOrder == SortOrder.Ascending ? comparisonResult > 0 : comparisonResult < 0;
        }
    }
}