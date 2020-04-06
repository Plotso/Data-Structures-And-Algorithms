namespace Algorithms.SearchingAlgorithms.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// A static class providing extension methods for using Searching Algorithms over IList
    /// </summary>
    public static class SearchingAlgorithmsExtension
    {
        /// <summary>
        /// Searches the entire <see cref="IList{T}"/> for X going through each item from the beginning. It has O(n) time complexity
        /// </summary>
        /// <param name="collection">The <see cref="IList{T}"/> containing all items through which the algorithm would search</param>
        /// <param name="x">The value that will be searched</param>
        /// <returns>If it finds the item, the index of X is returned, otherwise, null would be returned.</returns>
        public static int? LinearSearch(this IList<int> collection, int x)
        {
            var size = collection.Count;

            for (int i = 0; i < size; i++)
            {
                if (collection[i] == x)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Search a sorted <see cref="IList{T}"/> by repeatedly dividing the search interval in half. It has O(n) time complexity
        /// </summary>
        /// <param name="collection">The <see cref="IList{T}"/> containing all items through which the algorithm would search</param>
        /// <param name="x">The value that will be searched</param>
        /// <returns>Returns the index of X if found, othersie, null will be returned.</returns>
        public static int? BinarySearch(this IList<int> collection, int x)
        {
            var startingIndex = 0;
            var endingIndex = collection.Count - 1;

            while (startingIndex <= endingIndex)
            {
                var middleIndex = startingIndex + (endingIndex - startingIndex) / 2;

                if (collection[middleIndex] == x)
                {
                    return middleIndex;
                }

                if (collection[middleIndex] < x)
                {
                    startingIndex = middleIndex + 1;
                }
                else
                {
                    endingIndex = middleIndex - 1;
                }
            }

            return null;
        }
        
        /// <summary>
        /// InterpolationSearch works better than BinarySearch in most cases
        /// </summary>
        /// <param name="collection">The <see cref="IList{T}"/> containing all items through which the algorithm would search</param>
        /// <param name="x">The value that will be searched</param>
        /// <returns>Returns the index of X if found, othersie, null will be returned.</returns>
        public static int? InterpolationSearch(this IList<int> collection, int x)
        {
            var key = x;
            var sortedList = collection;

            var low = 0;
            var high = sortedList.Count - 1;

            while (sortedList[low] <= key && sortedList[high] >= key)
            {
                var mid = low + ((key - sortedList[low]) * (high - low)) / (sortedList[high] - sortedList[low]);

                if (sortedList[mid] < key)
                {
                    low = mid + 1;
                }
                else if (sortedList[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (sortedList[low] == key)
            {
                return low;
            }

            return null;
        }
    }
}
