namespace Algorithms.SearchingAlgorithms.InputBased
{
    using Contracts.Interfaces;

    /// <summary>
    /// Interpolation search algorithm has time complexity O(log n) in worst cases
    /// </summary>
    public class InterpolationSearchAlgorithm
    {
        /// <summary>
        /// Returns the index of X if it's present in the InputArray. Otherwise, null would be returned.
        /// NOTE: The InputArray in the ISearchingAlgorithmInput should be sorted ascending, otherwise the algorithm wouldn't work.
        /// </summary>
        /// <param name="input">The input containing the InputArray<see cref="IList{int}"/> and X</param>
        /// <param name="recursiveSearch">Specify whether algorithm should be executed recursively</param>
        public int? InterpolationSearch(ISearchingAlgorithmInput input, bool recursiveSearch = false)
        {
            var key = input.X;
            var sortedList = input.InputArray;

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