namespace Algorithms.SortingAlgorithms.Simple
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of Selection Sort algorithms
    /// </summary>
    public class SelectionSort
    {
        public void Sort(IList<int> list)
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
    }
}