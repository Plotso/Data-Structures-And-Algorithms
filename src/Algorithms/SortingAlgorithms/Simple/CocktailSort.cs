namespace Algorithms.SortingAlgorithms.Simple
{
    using System.Collections.Generic;

    /// <summary>
    /// CocktailSort is an optimization of the BubbleSort algorithm, although it still has same complexity
    /// </summary>
    public class CocktailSort
    {
        public void Sort(IList<int> list)
        {
            var n = list.Count;
            var swappedElement = true;
            var startingIndex = 0;

            while (swappedElement)
            {
                swappedElement = false;
                for (int i = startingIndex; i < n - 1; i++)
                {
                    if (ShouldSwap(list[i], list[i + 1]))
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swappedElement = true;
                    }
                }

                if (!swappedElement)
                {
                    break;
                }
                
                //reset flag so thatt it can be used in next iteration
                swappedElement = false;
                
                
                for (int i = n - 2; i >= startingIndex; i--)
                {
                    if (ShouldSwap(list[i], list[i + 1]))
                    {
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swappedElement = true;
                    }
                }

                startingIndex++;
            }
        }
        
        private bool ShouldSwap(int firstElement, int secondElement)
        {
            return firstElement > secondElement;
        }
    }
}