namespace Algorithms.SearchingAlgorithms.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// A static class providing methods for Linear Search that doesn't use SearchingAlgorithmInput
    /// </summary>
    public static class SearchingAlgorithmsExtension
    {
        /// <summary>
        /// Searches the entire <see cref="IList{T}"/> for X going through each item from the beginning. If it finds the item, the index of X is returned, otherwise, -1 would be returned.
        /// </summary>
        /// <param name="collection">The <see cref="IList{T}"/> containing all items through which the algorithm would search</param>
        /// <param name="x">The value that will be searched</param>
        /// <returns></returns>
        public static int LinearSearch(this IList<int> collection, int x)
        {
            int size = collection.Count;

            for (int i = 0; i < size; i++)
            {
                if (collection[i] == x)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Search a sorted <see cref="IList{T}"/> by repeatedly dividing the search interval in half. Returns the index of X if found, othersie, -1 will be returned.
        /// </summary>
        /// <param name="collection">The <see cref="IList{T}"/> containing all items through which the algorithm would search</param>
        /// <param name="x">The value that will be searched</param>
        /// <returns></returns>
        public static int BinarySearch(this IList<int> collection, int x)
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

            return -1;
        }
    }
}
