namespace Algorithms.SearchingAlgorithms.InputBased
{
    using Contracts.Interfaces;
    using System.Collections.Generic;

    public class LinearSearcher
    {

        /// <summary>
        /// Searches the InputArray in for the X. If it finds the item, the index of X is returned, otherwise, -1 would be returned.
        /// </summary>
        /// <param name="input">The input containing the InputArray and X</param>
        /// <returns></returns>
        public int LinearSearch(ISearchingAlgorithmInput input)
        {
            IList<int> list = input.InputArray;
            int n = list.Count;

            for (int i = 0; i < n; i++)
            {
                if (list[i] == input.X)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
