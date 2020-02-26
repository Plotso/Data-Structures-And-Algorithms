namespace Algorithms.SortingAlgorithms
{
    using System.Collections.Generic;
    /// <summary>
    /// BubbleSort Algorithm has complexity O(n*n) in worst case
    /// </summary>
    public class BubbleSortAlgorithm
    {
        public void Sort(IList<int> list, SortOrder sortOrder = SortOrder.Ascending)
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
                    return;
                }
            }
        }

        private bool ShouldSwap(int firstElement, int secondElement, SortOrder sortOrder) 
            => sortOrder == SortOrder.Ascending ?
                firstElement > secondElement :
                firstElement < secondElement;
    }
}