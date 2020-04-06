namespace Algorithms.SortingAlgorithms.Simple
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of Insertion Sort Algorithm
    /// </summary>
    public class InsertionSort
    {
        public void Sort(IList<int> list)
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
    }
}