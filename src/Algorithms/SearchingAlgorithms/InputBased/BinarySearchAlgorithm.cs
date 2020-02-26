namespace Algorithms.SearchingAlgorithms.InputBased
{
    using Contracts.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// Binary search algorithm has time complexity O(log n) in worst cases
    /// </summary>
    public class BinarySearchAlgorithm
    {
        private const int FirstIndex = 0;

        /// <summary>
        /// Returns the index of X if it's present in the InputArray. Otherwise, null would be returned.
        /// NOTE: The InputArray in the ISearchingAlgorithmInput should be sorted ascending, otherwise the algorithm wouldn't work.
        /// </summary>
        /// <param name="input">The input containing the InputArray<see cref="IList{int}"/> and X</param>
        /// <param name="recursiveSearch">Specify whether algorithm should be executed recursively</param>
        public int? BinarySearch(ISearchingAlgorithmInput input, bool recursiveSearch = false)
        {
            var lastIndex = input.InputArray.Count - 1;

            if (recursiveSearch)
            {
                return RecursiveBinarySearch(input.InputArray, FirstIndex, lastIndex, input.X);
            }

            return IterativeBinarySearch(input.InputArray, input.X);
        }

        private int? RecursiveBinarySearch(
            IList<int> list,
            int startingIndex,
            int endingIndex,
            int x)
        {
            if (endingIndex > startingIndex)
            {
                var middleIndex = CalculateMiddleIndex(startingIndex, endingIndex);

                if (list[middleIndex] == x)
                {
                    return middleIndex;
                }

                if (list[middleIndex] > x)
                {
                    return RecursiveBinarySearch(list, startingIndex, middleIndex - 1, x);
                }

                return RecursiveBinarySearch(list, middleIndex + 1, endingIndex, x);
            }

            return null;
        }

        private static int? IterativeBinarySearch(IList<int> list, int x)
        {
            var startingIndex = 0;
            var endingIndex = list.Count - 1;

            while (startingIndex <= endingIndex)
            {
                var middleIndex = CalculateMiddleIndex(startingIndex, endingIndex);

                if (list[middleIndex] == x)
                {
                    return middleIndex;
                }

                if (list[middleIndex] < x)
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

        private static int CalculateMiddleIndex(int startingIndex, int endingIndex) 
            => startingIndex + (endingIndex - startingIndex) / 2;
    }
}
